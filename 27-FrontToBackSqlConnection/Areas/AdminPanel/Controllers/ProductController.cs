using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles ="Admin, Moderator, Mebmer")]
    public class ProductController : Controller
    {
        private readonly AppDB _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDB context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductGetVM> productGetVM = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductGetVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    SKU = p.SKU,
                    CategoryName = p.Category.Name,
                    Image = p.ProductImages.FirstOrDefault(p => p.IsPrimary == true).Image
                })
                .ToListAsync();

            return View(productGetVM);
        }

        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories.Where(p => !p.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(p => !p.IsDeleted).ToListAsync(),
            };

            return View(productCreateVM);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories
                .Where(c => !c.IsDeleted)
                .ToListAsync();

            if (!ModelState.IsValid) return View(productCreateVM);

            if (productCreateVM.MainPhoto is not null)
            {
                if (!productCreateVM.MainPhoto.CheckFiletype("image/"))
                {
                    ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File type is incorrect");
                    return View(productCreateVM);
                }

                if (!productCreateVM.MainPhoto.CheckFileSize(FileSize.MB, 2))
                {
                    ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "size must be less than 2mb");
                    return View(productCreateVM);
                }
            }

            if (productCreateVM.HoverPhoto is not null)
            {

                if (!productCreateVM.HoverPhoto.CheckFileSize(FileSize.MB, 2))
                {
                    ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "size must be less than 2mb");
                    return View(productCreateVM);
                }

                if (!productCreateVM.HoverPhoto.CheckFiletype("image/"))
                {
                    ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File type is incorrect");
                    return View(productCreateVM);
                }
            }


            bool existCategory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(productCreateVM.CategoryId), "Category does't exist");
                return View(productCreateVM);
            }

            bool existTag = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t => t.Id == tagId));
            if (existTag)
            {
                ModelState.AddModelError(nameof(productCreateVM.TagIds), "do not exist");
                return View(productCreateVM);
            }

            ProductImage mainImage = new()
            {
                Image = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = true,
            };

            ProductImage hoverImage = new()
            {
                Image = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = false,
            };

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                CategoryId = productCreateVM.CategoryId.Value,
                SKU = productCreateVM.SKU,
                Description = productCreateVM.Description,
                ProductImages = new List<ProductImage> { mainImage, hoverImage }
            };

            if (productCreateVM.TagIds is not null)
            {
                product.ProductsTags = productCreateVM.TagIds.Select(tId => new ProductTag { TagId = tId }).ToList();
            }


            if (productCreateVM.AdditionalPhotos is not null)
            {
                string text = string.Empty;

                foreach (IFormFile file in productCreateVM.AdditionalPhotos)
                {
                    if (!file.CheckFiletype("image/"))
                    {
                        text += $"{file.FileName} type is not correct";
                        continue;
                    }

                    if (!file.CheckFileSize(FileSize.MB, 2))
                    {
                        text += $"{file.FileName} size is not correct";
                        continue;
                    }

                    product.ProductImages.Add(new ProductImage
                    {
                        Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = null,
                    });
                }
                TempData["FileWarning"] = text;
            }


            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductsTags).FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return NotFound();

            ProductUpdateVM productUpadateVM = new()
            {
                Name = product.Name,
                Price = product.Price,
                SKU = product.SKU,
                Description = product.Description,
                CategoryId = product.CategoryId,
                TagIds = product.ProductsTags.Select(pt => pt.TagId).ToList(),
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync(),
                //productImages = await _context.ProductsImages.Where(
            };

            return View(productUpadateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpadateVM)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products.Include(p =>p.ProductImages).Include(p => p.ProductsTags).FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) return NotFound();

            productUpadateVM.Categories = await _context.Categories.Where(c => !!c.IsDeleted).ToListAsync();
            productUpadateVM.Tags = await _context.Tags.Where(t => !!t.IsDeleted).ToListAsync();
            productUpadateVM.ProductImages = product.ProductImages;

            if (!ModelState.IsValid)
            {
                return View(productUpadateVM);
            }
             

            bool existCategory = productUpadateVM.Categories.Any(c => c.Id == productUpadateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(productUpadateVM.CategoryId), "not exist");
                return View(productUpadateVM);
            }

            if (productUpadateVM.TagIds is not null)
            {
                bool existTag = productUpadateVM.TagIds.Any(tagId => productUpadateVM.Tags.Exists(t => t.Id == tagId));
                if (existTag)
                {
                    ModelState.AddModelError(nameof(productUpadateVM.TagIds), "not exist");
                    return View(productUpadateVM);
                }
            } 

            if (productUpadateVM.TagIds is not null)
            {
                productUpadateVM.TagIds = new();
            }

            if (productUpadateVM.TagIds is not null)
            {
                List<ProductTag> deleteTags = product.ProductsTags
                    .Where(pTag => !productUpadateVM.TagIds
                    .Exists(tId => tId == pTag.TagId)).ToList();

                List<ProductTag> createdTags = productUpadateVM.TagIds
                    .Where(tId => !product.ProductsTags
                    .Exists(pTag => pTag.TagId == tId))
                    .Select(tId => new ProductTag { TagId = tId, ProductId = product.Id })
                    .ToList();


                _context.ProductTags.RemoveRange(deleteTags);
                _context.ProductTags.AddRange(createdTags);
            }

            if (productUpadateVM.MainPhoto is not null)
            {
                string fileName = await productUpadateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");

                ProductImage mainImage = product.ProductImages.FirstOrDefault(p => p.IsPrimary == true);

                mainImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                product.ProductImages.Remove(mainImage);

                product.ProductImages.Add(new ProductImage
                {
                    Image = fileName,
                    IsPrimary = true,
                });
            }

            if (productUpadateVM.HoverPhoto is not null)
            {
                string fileName = await productUpadateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");

                ProductImage hoverImage = product.ProductImages.FirstOrDefault(p => p.IsPrimary == true);

                hoverImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                product.ProductImages.Remove(hoverImage);

                product.ProductImages.Add(new ProductImage
                {
                    Image = fileName,
                    IsPrimary = false,
                });
            }

            if (productUpadateVM.ImageIds is null)
            {
                productUpadateVM.ImageIds = new List<int>();
            }

            var deletedImages = product.ProductImages
                .Where(pi => !productUpadateVM.ImageIds
                .Exists(imgId => imgId == pi.Id) && pi.IsPrimary == null)
                .ToList();

            deletedImages.ForEach(di => di.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images"));

            _context.ProductImages.RemoveRange(deletedImages);

            if (productUpadateVM.AdditionalPhotos is not null)
            {
                string text = string.Empty;

                foreach (IFormFile file in productUpadateVM.AdditionalPhotos)
                {
                    
                    if (!file.CheckFiletype("image/"))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} type is not correct</p>";
                        continue;
                    }

                    if (!file.CheckFileSize(FileSize.MB, 2))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} size is not correct</p>";
                        continue;
                    }

                    product.ProductImages.Add(new ProductImage
                    {

                        Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = null,
                    });
                }
                TempData["FileWarning"] = text;
            } 

            product.Name = productUpadateVM.Name;
            product.Price = productUpadateVM.Price;
            product.SKU = productUpadateVM.SKU;
            product.Description = productUpadateVM.Description;
            product.CategoryId = productUpadateVM.CategoryId.Value;


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
