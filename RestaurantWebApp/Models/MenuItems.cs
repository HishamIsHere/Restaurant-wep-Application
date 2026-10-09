using System.ComponentModel.DataAnnotations.Schema;
using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class MenuItems : BaseEntity
    {
        public bool IsPopular { get; set; }
        public string MenuItemsTitle { get; set; } = string.Empty;

        public string MenuItemsFirstDesc { get; set; } = string.Empty;

        public string? MenuItemsSecondDesc { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MenuItemsPrice { get; set; }
        public string? MenuItemsImageURL { get; set; }
        public int MenuCategoryId { get; set; }
        public virtual MenuCategory? MenuCategory { get; set; }
    }
}
