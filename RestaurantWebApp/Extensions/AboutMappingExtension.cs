using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class AboutMappingExtension
    {
        public static About ToModel(this AboutViewModel model)
        {
            return new About
            {
                IsActive = model.IsActive,
                Id = model.Id,
                AboutImageURL = model.AboutImageURL,
                AboutTitle = model.AboutTitle,
                AboutBrief = model.AboutBrief,
                AboutDesc = model.AboutDesc,
                AboutFooterDesc = model.AboutFooterDesc,
            };

        }
        public static AboutViewModel ToViewModel(this About model)
        {
            return new AboutViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                AboutImageURL = model.AboutImageURL,
                AboutTitle = model.AboutTitle,
                AboutBrief = model.AboutBrief,
                AboutDesc = model.AboutDesc,
                AboutFooterDesc = model.AboutFooterDesc,
            };

        }
        public static List<AboutViewModel> ToViewModelList(this List<About> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<About> ToViewModelList(this List<AboutViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
