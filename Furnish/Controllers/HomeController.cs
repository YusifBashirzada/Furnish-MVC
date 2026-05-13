using Furnish.Data;
using Furnish.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furnish.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            var products = await _context.Products.ToListAsync();
            var categories = await _context.Categories.ToListAsync();
            var homeVM = new HomeVM { Sliders = sliders, Categories = categories, Products = products };
            return View(homeVM);
        }
    }
}
