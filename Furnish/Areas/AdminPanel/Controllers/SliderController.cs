using _27_FrontToBackSqlConnection.Utilities.Extensions;
using Furnish.Areas.AdminPanel.ViewModels;
using Furnish.Data;
using Furnish.Models;
using Furnish.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.Where(s => !s.isDeleted).ToListAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {
            if (!sliderCreateVM.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is incorrect!");
                return View();
            }

            if (!sliderCreateVM.Photo.CheckFileSize(FileSize.MB, 2))
            {
                ModelState.AddModelError("Photo", "File size must be less than 2mb!");
                return View();
            }

            Slider slider = new()
            {
                Discount = sliderCreateVM.Discount,
                Name = sliderCreateVM.Name,
                Description = sliderCreateVM.Description,
                Price = sliderCreateVM.Price,
                Image = await sliderCreateVM.Photo.CreateFile(_env.WebRootPath, "assets", "images", "website-images")
            };

            await _context.Sliders.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders.Where(s => !s.isDeleted).FirstOrDefaultAsync(s => s.id == id);

            if (slider == null) return NotFound();

            slider.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

            _context.Remove(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .FirstOrDefaultAsync(s => s.id == id && !s.isDeleted);

            if (slider == null) return NotFound();

            return View(slider);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders.Where(s => !s.isDeleted).FirstOrDefaultAsync(s => s.id == id);

            if (slider == null) return NotFound();

            SliderUpdateVM sliderUpdateVM = new()
            {
                Discount = slider.Discount,
                Name = slider.Name,
                Description = slider.Description,
                Price = slider.Price,
                Image = slider.Image,
            };

            return View(sliderUpdateVM);
        }
    }
}