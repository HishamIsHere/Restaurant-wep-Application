using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class Partners : BaseEntity
    {
        public string PartnersImageURL { get; set; } = string.Empty;
        public string PartnersAltImageURL { get; set; } = string.Empty;
        public string PartnersLink { get; set; } = string.Empty;
    }
}
