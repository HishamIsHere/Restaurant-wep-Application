using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class ServicesMappingExtension
    {
        public static Services ToModel(this ServicesViewModel model)
        {
            return new Services
            {
                IsActive = model.IsActive,
                Id = model.Id,
                ServicesDesc = model.ServicesDesc,
                ServicesTitle = model.ServicesTitle,
                ServicesIcon = model.ServicesIcon,
            };

        }
        public static ServicesViewModel ToViewModel(this Services model)
        {
            return new ServicesViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                ServicesDesc = model.ServicesDesc,
                ServicesTitle = model.ServicesTitle,
                ServicesIcon = model.ServicesIcon,
            };

        }
        public static List<ServicesViewModel> ToViewModelList(this List<Services> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<Services> ToViewModelList(this List<ServicesViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
