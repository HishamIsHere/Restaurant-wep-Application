using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class MenuCategoryMappingExtension
    {
        public static MenuCategory ToModel(this MenuCategoryViewModel model)
        {
            return new MenuCategory
            {
                IsActive = model.IsActive,
                Id = model.Id,
                MenuCategoryName = model.MenuCategoryName,
                MenuCategoryIcon = model.MenuCategoryIcon,



            };

        }
        public static MenuCategoryViewModel ToViewModel(this MenuCategory model)
        {
            return new MenuCategoryViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                MenuCategoryName = model.MenuCategoryName,
                MenuCategoryIcon = model.MenuCategoryIcon,
            };

        }
        public static List<MenuCategoryViewModel> ToViewModelList(this List<MenuCategory> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<MenuCategory> ToViewModelList(this List<MenuCategoryViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
