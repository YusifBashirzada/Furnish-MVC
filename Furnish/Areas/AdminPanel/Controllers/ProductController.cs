using Furnish.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Furnish.Areas.AdminPanel.Controllers
{
    public class ProductController:Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        [Area("AdminPanel")]
        public async Task<IActionResult> Index()
        {
            var product = await _context.Products.ToListAsync();
            return View(product);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
