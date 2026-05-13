namespace Furnish.Models
{
    public class Slider : BaseEntity
    {
        public int Discount { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
    }
}
