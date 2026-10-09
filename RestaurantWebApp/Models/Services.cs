using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class Services : BaseEntity
    {
        public string ServicesTitle { get; set; } = string.Empty;
        public string ServicesDesc { get; set; } = string.Empty;
        public string ServicesIcon { get; set; } = string.Empty;
    }
}
