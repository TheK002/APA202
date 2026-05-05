using _26_DynamicPropertiesViewModel.Models;
using _26_DynamicPropertiesViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _26_DynamicPropertiesViewModel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        List<Student> _students = new List<Student>
        {
            new Student{Id=1, Name="a", Surname="A"},
            new Student{Id=2, Name="b", Surname="B"},
            new Student{Id=3, Name="c", Surname="C"},
        };

        List<Teacher> _teachers = new List<Teacher>
        {
            new Teacher{Id=1, Name="aa"},
            new Teacher{Id=2, Name="bb"},
        };


        public IActionResult Index()
        {
            ViewData["Students"] = _students;

            HomeVM homeVM = new()
            {
                Teachers = _teachers,
                Students = _students
            };
            return View(homeVM);
        }

        [Route("Korp")]
        public IActionResult CSales()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
