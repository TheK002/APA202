using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        List<Slider> _sliders = new List<Slider>
        { 
            new Slider() {Title="111", Subtitle="11", Description="1", Image="1-270x300.webp", Order=1 },
            new Slider() {Title="222", Subtitle="22", Description="2", Image="1-270x300.webp", Order=2 },
            new Slider() {Title="333", Subtitle="33", Description="3", Image="1-270x300.webp", Order=3 },

        };


        public IActionResult Index()
        {
            _context.AddRange(_sliders);
            _context.SaveChanges();

            HomeVM HomeVM = new()
            {
                Sliders = _sliders.OrderBy(s=>s.Order).Take(2).ToList() 

            };

            return View(HomeVM);
        }

        
    }
}
