using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Sliders;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extensions;
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
        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {
            if (!ModelState.IsValid) return View();

            //if (!slider.Photo.ContentType.Contains("image/"))
            if (!sliderCreateVM.Photo.CheckFiletype("image/"))

            {
                ModelState.AddModelError(nameof(sliderCreateVM.Photo), "type is incorrect");
                return View();
            }

            //if (slider.Photo.Length > 2 * 1024 * 1024)
            if (!sliderCreateVM.Photo.CheckFileSize(FileSize.MB, 2))
            {
                ModelState.AddModelError(nameof(sliderCreateVM.Photo), "File size is above 2mb");
                return View();

            }

            Slider slider = new()
            {
                Title = sliderCreateVM.Title,
                Subtitle = sliderCreateVM.Subtitle,
                Description = sliderCreateVM.Description,
                Order = sliderCreateVM.Order,
                Image = await sliderCreateVM.Photo.CreateFile(_env.WebRootPath, "assets", "images", "website-images")
            };

            await _context.Sliders.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();
            {
                Slider? slider = await _context.Sliders
                    .Where(s => !s.IsDeleted)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (slider is null) return NotFound();

                SliderDetailVM sliderDetailVM = new()
                {
                    Title = slider.Title,
                    Subtitle = slider.Subtitle,
                    Description = slider.Description,
                    Order = slider.Order,
                    Image = slider.Image
                };

                return View(sliderDetailVM);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();
            {
                Slider? slider = await _context.Sliders
                    .Where(s => !s.IsDeleted)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (slider is null) return NotFound();

                _context.Remove(slider);

                await _context.SaveChangesAsync();

                slider.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();
            {
                Slider? slider = await _context.Sliders
                    .Where(s => !s.IsDeleted)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (slider is null) return NotFound();

                SliderUpdateVM sliderUpdateVM = new()
                {
                    Image = slider.Image,
                    Title = slider.Title,
                    Subtitle = slider.Subtitle,
                    Description = slider.Description,
                    Order = slider.Order
                };

                return View(sliderUpdateVM);


            }

        }
    }
}
