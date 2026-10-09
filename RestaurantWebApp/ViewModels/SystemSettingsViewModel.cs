using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class SystemSettingsViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Dark logo image")]
        public string LogoDarkURL { get; set; } = string.Empty;
        public IFormFile? LogoDarkFile { get; set; }
        [Display(Name = "Light logo image")]
        public string LogoLightURL { get; set; } = string.Empty;
        public IFormFile? LogoLightFile { get; set; }
        [Display(Name ="Side bar background image")]
        public string SliderBackgroundURL { get; set; } = string.Empty;
        public IFormFile? SliderBackgroundFile { get; set; }
        [Display(Name = "Popular section background image")]
        public string PopularBackgroundURL { get; set; } = string.Empty;
        public IFormFile? PopularBackgroundFile { get; set; }
        [Display(Name = "Reservation image")]
        public string ReservationImageURL { get; set; } = string.Empty;
        public IFormFile? ReservationImageFile { get; set; }
        public string Location { get; set; } = string.Empty;
        public string FooterText { get; set; } = string.Empty;
    }
}
