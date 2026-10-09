using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class SocialMediaViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [Display(Name ="Social media icon")]
        public string SocialMediaIcon { get; set; } = string.Empty;
        [Display(Name = "Social media link")]
        public string SocialMediaLink { get; set; } = string.Empty;
    }
}
