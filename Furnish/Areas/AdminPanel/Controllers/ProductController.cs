using Microsoft.AspNetCore.Mvc;

namespace Furnish.Areas.AdminPanel.Controllers
{
    public class ProductController:Controller
    {
        [Area("AdminPanel")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
