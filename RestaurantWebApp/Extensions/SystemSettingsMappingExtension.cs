using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class SystemSettingsMappingExtension
    {
        public static SystemSettings ToModel(this SystemSettingsViewModel model)
        {
            return new SystemSettings
            {
                IsActive = model.IsActive,
                Id = model.Id,
                LogoDarkURL = model.LogoDarkURL,
                LogoLightURL = model.LogoLightURL,
                SliderBackgroundURL = model.SliderBackgroundURL,
                PopularBackgroundURL = model.PopularBackgroundURL,
                ReservationImageURL = model.ReservationImageURL,
                Location = model.Location,
                FooterText = model.FooterText,


            };

        }
        public static SystemSettingsViewModel ToViewModel(this SystemSettings model)
        {
            return new SystemSettingsViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                LogoDarkURL = model.LogoDarkURL,
                LogoLightURL = model.LogoLightURL,
                SliderBackgroundURL = model.SliderBackgroundURL,
                PopularBackgroundURL = model.PopularBackgroundURL,
                ReservationImageURL = model.ReservationImageURL,
                Location = model.Location,
                FooterText = model.FooterText,
            };

        }
        public static List<SystemSettingsViewModel> ToViewModelList(this List<SystemSettings> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<SystemSettings> ToViewModelList(this List<SystemSettingsViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
