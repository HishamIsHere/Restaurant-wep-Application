using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class SocialMediaMappingExtension
    {
        public static SocialMedia ToModel(this SocialMediaViewModel model)
        {
            return new SocialMedia
            {
                IsActive = model.IsActive,
                Id = model.Id,
                SocialMediaLink = model.SocialMediaLink,
                SocialMediaIcon = model.SocialMediaIcon,

            };

        }
        public static SocialMediaViewModel ToViewModel(this SocialMedia model)
        {
            return new SocialMediaViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                SocialMediaLink = model.SocialMediaLink,
                SocialMediaIcon = model.SocialMediaIcon,
            };

        }
        public static List<SocialMediaViewModel> ToViewModelList(this List<SocialMedia> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<SocialMedia> ToViewModelList(this List<SocialMediaViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
