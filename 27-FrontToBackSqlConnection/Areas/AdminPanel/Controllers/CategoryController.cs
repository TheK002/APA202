using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]  // This MUST match exactly
    [Route("adminpanel/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly AppDB _context;

        public CategoryController(AppDB context) 
        { 
            _context = context;
        } 

        public async Task<IActionResult> Index()
        { 
            List<Category> categories = await _context.Categories
                .Include(c=>c.Products.Where(p=>!p.IsDeleted))
                .Where(c=>!c.IsDeleted)
                .ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool existCategory = await _context.Categories.AnyAsync(c => c.Name.Trim() == category.Name.Trim());


            if (existCategory)
            {
                ModelState.AddModelError("Name", "already exist");
                return View(category);
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();
            
            Category? category = await _context.Categories.Include(c=>c.Products).FirstOrDefaultAsync(c=> c.Id == id);

            if (category is null) return NotFound();
            
            return View(category);

        }
    }
}
