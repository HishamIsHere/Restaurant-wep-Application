using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class Slider : BaseEntity
    {
        public string SliderImageURL {  get; set; } = string.Empty;
        public string SliderTitle { get; set; } = string.Empty;
        public string SliderBrief { get; set; } = string.Empty;
        public string SliderDesc { get; set; } = string.Empty;
    }
}
