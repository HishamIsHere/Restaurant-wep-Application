using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class Banner : BaseEntity
    {
        public bool BannerIsPrimary { get; set; }
        public string BannerTitle { get; set; } = string.Empty;
        public string BannerBrief { get; set; } = string.Empty;
        public string BannerDesc { get; set; } = string.Empty;
        public string BannerImageURL { get; set; } = string.Empty;
    }
}
