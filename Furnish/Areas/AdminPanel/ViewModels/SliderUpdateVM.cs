using System.ComponentModel.DataAnnotations.Schema;

namespace Furnish.Areas.AdminPanel.ViewModels
{
    public class SliderUpdateVM
    {
        public int? Discount { get; set; }
        public string? Name { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }
    }
}
