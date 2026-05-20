using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Services;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDB _context;
        public ShopController(AppDB context)
        {
            _context = context;
        }

        public EmailService EmailService { get; }

        public IActionResult Index()
        {
            List<Product> products = _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProductImages.Where(pi => pi.IsPrimary !=   null && !pi.IsDeleted))
                .ToList();
            ShopVM shopVM = new()
            {
                Products = products,
            };

            return View(shopVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductsTags)
                .ThenInclude(pt=>pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            List<Product> relatedProducts = await _context.Products
                .Where (p => !p.IsDeleted)
                .Where (p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .Include (p => p.ProductImages.Where(pi => pi.IsPrimary != null && pi.IsDeleted==false))
                .ToListAsync();

            DetailVM detailVM = new()
            {
                Product = product,
                RelatedProducts = relatedProducts,
            };

            return View(detailVM);
        }
    }
}
