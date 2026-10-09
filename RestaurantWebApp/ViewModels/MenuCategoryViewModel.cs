using RestaurantWebApp22092026.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class MenuCategoryViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [Display(Name ="Menu category name: ")]
        public string MenuCategoryName { get; set; } = string.Empty;
        [Display(Name = "Menu category icon: ")]
        public string MenuCategoryIcon { get; set; } = string.Empty;
        public ICollection<MenuItems> MenuItems { get; set; } = new List<MenuItems>();
    }
}
