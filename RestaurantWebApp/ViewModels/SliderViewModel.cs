using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class SliderViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Slider Image")]
        public string SliderImageURL { get; set; } = string.Empty;
        public IFormFile? SliderImageFile { get; set; }
        [Display(Name = "Slider Title")]
        public string SliderTitle { get; set; } = string.Empty;
        [Display(Name = "Slider Brief")]
        public string SliderBrief { get; set; } = string.Empty;
        [Display(Name = "Slider Description")]
        public string SliderDesc { get; set; } = string.Empty;
    }
}
