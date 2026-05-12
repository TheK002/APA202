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

        public async Task<IActionResult> Index()
        {

            List<Slider> sliders = await _context.Sliders
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Order)
                .Take(2)
                .ToListAsync();
             
            List<Product> products = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null))
                .Take(4)
                .ToListAsync();

            HomeVM HomeVM = new()
            {
                Sliders = sliders,
                Products = products

            };

            return View(HomeVM);
        }

        
    }
}
