using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class BannerViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Primary banner")]
        public bool BannerIsPrimary { get; set; }
        [Display(Name = "Banner title")]
        public string BannerTitle { get; set; } = string.Empty;
        [Display(Name = "Banner brief")]
        public string BannerBrief { get; set; } = string.Empty;
        [Display(Name = "Banner description")]
        public string BannerDesc { get; set; } = string.Empty;
        [Display(Name = "Banner Image")]
        public string BannerImageURL { get; set; } = string.Empty;
        public IFormFile? BannerImageFile { get; set; }
    }
}
