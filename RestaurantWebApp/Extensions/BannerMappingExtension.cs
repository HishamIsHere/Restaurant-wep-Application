using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class BannerMappingExtension
    {
        public static Banner ToModel(this BannerViewModel model)
        {
            return new Banner
            {
                IsActive = model.IsActive,
                Id = model.Id,
                BannerImageURL = model.BannerImageURL,
                BannerTitle = model.BannerTitle,
                BannerBrief = model.BannerBrief,
                BannerDesc = model.BannerDesc,
                BannerIsPrimary = model.BannerIsPrimary,
            };

        }
        public static BannerViewModel ToViewModel(this Banner model)
        {
            return new BannerViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                BannerImageURL = model.BannerImageURL,
                BannerTitle = model.BannerTitle,
                BannerBrief = model.BannerBrief,
                BannerDesc = model.BannerDesc,
                BannerIsPrimary = model.BannerIsPrimary,
            };

        }
        public static List<BannerViewModel> ToViewModelList(this List<Banner> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<Banner> ToViewModelList(this List<BannerViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
