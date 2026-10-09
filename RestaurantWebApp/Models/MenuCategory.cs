using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class MenuCategory : BaseEntity
    {
        public string MenuCategoryName { get; set; } = string.Empty;
        public string MenuCategoryIcon { get; set; } = string.Empty;
        public ICollection<MenuItems> MenuItems { get; set; } = new List<MenuItems>();
    }
}
