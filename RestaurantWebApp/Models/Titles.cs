using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class Titles : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string TitleDesc { get; set; } = string.Empty;
        public string TitleKeyword { get; set; } = string.Empty;
    }
}
