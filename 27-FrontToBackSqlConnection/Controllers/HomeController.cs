using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Services;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDB _context;

        public HomeController(AppDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Product product = _context.Products.FirstOrDefault();

            Category category = _context.Categories.FirstOrDefault(c => c.Id==product.CategoryId);

            List<Slider> sliders = _context.Sliders
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Order)
                .Take(2)
                .ToList();
             
            List<Product> products = _context.Products.Where(p => !p.IsDeleted).Include(p => p.ProductImages).ToList();

            HomeVM HomeVM = new()
            {
                Sliders = sliders,

                Products = products

            };

            return View(HomeVM);
        }

        
    }
}
