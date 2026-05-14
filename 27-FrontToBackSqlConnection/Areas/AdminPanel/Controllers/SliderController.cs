using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    public class SliderController : Controller
    {
        private readonly AppDB _context;

        public SliderController(AppDB context) 
        {
            _context = context;  
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> slides = await _context.Sliders.Where(s => s.IsDeleted).ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
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

            string path = "C:\\Users\\ilkin\\OneDrive\\Desktop\\APA202\\27-FrontToBackSqlConnection\\wwwroot\\assets\\images\\website-images\\1--1rnu4p.png";

            FileStream fileStream = new FileStream(path, FileMode.Create);

            await slider.Photo.CopyToAsync(fileStream);

            fileStream.Close();
            
            slider.Image = slider.Photo.FileName;

            await _context.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
