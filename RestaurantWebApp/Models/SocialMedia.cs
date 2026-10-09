using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class SocialMedia : BaseEntity
    {
        public string SocialMediaIcon { get; set; } = string.Empty;
        public string SocialMediaLink { get; set; } = string.Empty;
    }
}
