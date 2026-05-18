using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
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
                .Where(p=>!p.IsDeleted)
                .Select(p=> new ProductGetVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    SKU = p.SKU,
                    CategoryName = p.Category.Name,
                    Image = p.ProductImages.FirstOrDefault().Image
                })
                .ToListAsync();

            return View(productGetVM);
        }

        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories
                .Where(p=>!p.IsDeleted)
                .ToListAsync(),

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

            bool existCategory = productCreateVM.Categories.Any(c=>c.Id == productCreateVM.CategoryId);

            if (!existCategory)
            {
                ModelState.AddModelError(nameof(productCreateVM.CategoryId), "Category does't exist");
                return View(productCreateVM);
            }

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                CategoryId = productCreateVM.CategoryId.Value,
                SKU = productCreateVM.SKU,
                Description = productCreateVM.Description,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    }
}
