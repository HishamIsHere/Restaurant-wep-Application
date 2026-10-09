using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class SystemSettings : BaseEntity
    {
        public string LogoDarkURL { get; set; } = string.Empty;
        public string LogoLightURL { get; set; } = string.Empty;
        public string SliderBackgroundURL { get; set; } = string.Empty;
        public string PopularBackgroundURL { get; set; } = string.Empty;
        public string ReservationImageURL { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string FooterText { get; set; } = string.Empty;
    }
}
