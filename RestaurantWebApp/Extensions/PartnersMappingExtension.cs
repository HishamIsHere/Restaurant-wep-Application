using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class PartnersMappingExtension
    {
        public static Partners ToModel(this PartnersViewModel model)
        {
            return new Partners
            {
                IsActive = model.IsActive,
                Id = model.Id,
                PartnersImageURL = model.PartnersImageURL,
                PartnersAltImageURL = model.PartnersAltImageURL,
                PartnersLink = model.PartnersLink,

            };

        }
        public static PartnersViewModel ToViewModel(this Partners model)
        {
            return new PartnersViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                PartnersImageURL = model.PartnersImageURL,
                PartnersAltImageURL = model.PartnersAltImageURL,
                PartnersLink = model.PartnersLink,
            };

        }
        public static List<PartnersViewModel> ToViewModelList(this List<Partners> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<Partners> ToViewModelList(this List<PartnersViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
