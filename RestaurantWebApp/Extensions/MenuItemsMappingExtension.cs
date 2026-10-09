using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class MenuItemsMappingExtension
    {
        public static MenuItems ToModel(this MenuItemsViewModel model)
        {
            return new MenuItems
            {
                Id = model.Id,
                MenuItemsTitle = model.MenuItemsTitle,
                MenuItemsFirstDesc = model.MenuItemsFirstDesc,
                MenuItemsSecondDesc = model.MenuItemsSecondDesc,
                MenuItemsPrice = model.MenuItemsPrice,
                MenuItemsImageURL = model.MenuItemsImageURL,
                MenuCategoryId = model.MenuCategoryId,
                IsActive = model.IsActive,
                IsPopular = model.IsPopular,
            };
        }
        public static MenuItemsViewModel ToViewModel(this MenuItems model)
        {
            return new MenuItemsViewModel
            {
                Id = model.Id,
                MenuItemsTitle = model.MenuItemsTitle,
                MenuItemsFirstDesc = model.MenuItemsFirstDesc,
                MenuItemsSecondDesc = model.MenuItemsSecondDesc,
                MenuItemsPrice = model.MenuItemsPrice,
                MenuItemsImageURL = model.MenuItemsImageURL,
                MenuCategoryId = model.MenuCategoryId,
                MenuCategoryName = model.MenuCategory?.MenuCategoryName,
                IsPopular = model.IsPopular,
                IsActive = model.IsActive
            };
        }
        public static List<MenuItemsViewModel> ToViewModelList(this List<MenuItems> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();
        }
    }
}

