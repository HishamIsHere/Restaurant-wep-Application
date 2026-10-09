using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantWebApp22092026.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantWebApp22092026.ViewModels
{
    public class MenuItemsViewModel
    {
        public bool IsPopular { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Item title is required")]
        [Display(Name = "Item Title")]
        public string MenuItemsTitle { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Menu Description")]
        public string MenuItemsFirstDesc { get; set; } = string.Empty;
        [Display(Name = "Secondary/Popular Description")]
        public string? MenuItemsSecondDesc { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be greater than zero")]
        [Display(Name = "Price")]
        public decimal MenuItemsPrice { get; set; }
        [Required(ErrorMessage = "Please select a category")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid category")]
        [Display(Name = "Category")]
        public int MenuCategoryId { get; set; }
        public string? MenuCategoryName { get; set; }
        [Display(Name = "Item Image")]
        public IFormFile? MenuItemsImageFile { get; set; }
        public string? MenuItemsImageURL { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
