using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class SocialMediaFullViewModel
    {
        public int Id { get; set; }
        public int DeleteId { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Social media icon")]
        public string SocialMediaIcon { get; set; } = string.Empty;
        [Display(Name = "Social media link")]
        public string SocialMediaLink { get; set; } = string.Empty;
        public List<SocialMediaViewModel>? List { get; set; }

    }
}
