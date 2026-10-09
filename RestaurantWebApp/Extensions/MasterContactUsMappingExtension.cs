using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class MasterContactUsMappingExtension
    {
        public static MasterContactUs ToModel(this MasterContactUsViewModel model)
        {
            return new MasterContactUs
            {
                IsActive = model.IsActive,
                Id = model.Id,
                MasterContactUsText = model.MasterContactUsText,
                MasterContactUsLink = model.MasterContactUsLink,
                MasterContactUsIcon = model.MasterContactUsIcon,

            };

        }
        public static MasterContactUsViewModel ToViewModel(this MasterContactUs model)
        {
            return new MasterContactUsViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                MasterContactUsText = model.MasterContactUsText,
                MasterContactUsLink = model.MasterContactUsLink,
                MasterContactUsIcon = model.MasterContactUsIcon,
            };

        }
        public static List<MasterContactUsViewModel> ToViewModelList(this List<MasterContactUs> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<MasterContactUs> ToViewModelList(this List<MasterContactUsViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
