using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Route("adminpanel/[controller]/[action]")]
    public class SliderController : Controller
    {
        private readonly AppDB _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDB context, IWebHostEnvironment env) 
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> slides = await _context.Sliders.Where(s => !s.IsDeleted).ToListAsync();

            return View(slides);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            

            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError(nameof(Slider.Photo), "type is incorrect");
                return View();
            }

            if (slider.Photo.Length > 2 * 1024 * 1024)
            {
            ModelState.AddModelError(nameof(Slider.Photo), "File size is above 2mb");
            return View();

            }

            string fileName = string.Concat(Guid.NewGuid().ToString(), slider.Photo.FileName);

            string path = Path.Combine(_env.WebRootPath, "assets", "images", "brand", slider.Photo.FileName);

            FileStream fileStream = new FileStream(path, FileMode.Create);

            await slider.Photo.CopyToAsync(fileStream);

            fileStream.Close();
            
            slider.Image = fileName;

            await _context.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }
}
