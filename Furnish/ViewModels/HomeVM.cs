using Furnish.Models;

namespace Furnish.ViewModels
{
    public class HomeVM
    {
        public List<Slider>? Sliders { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Product>? Products { get; set; }
    }
}
