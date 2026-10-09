using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class MasterContactUs : BaseEntity
    {
        public string MasterContactUsIcon {  get; set; } = string.Empty;
        public string MasterContactUsText { get; set; } = string.Empty;
        public string MasterContactUsLink { get; set; } = string.Empty;
    }
}
