using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class About : BaseEntity
    {
        public string AboutTitle { get; set; } = string.Empty;
        public string AboutBrief { get; set; } = string.Empty;
        public string AboutDesc { get; set; } = string.Empty;
        public string AboutImageURL { get; set; } = string.Empty;
        public string AboutFooterDesc { get; set; } = string.Empty;

    }
}
