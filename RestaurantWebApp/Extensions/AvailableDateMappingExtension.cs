using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class AvailableDateMappingExtension
    {
        public static AvailableDate ToModel(this AvailableDateViewModel model)
        {
            return new AvailableDate
            {
                Id = model.Id,
                Date = model.Date,
                IsActive = model.IsActive
            };
        }
        public static AvailableDateViewModel ToViewModel(this AvailableDate model)
        {
            return new AvailableDateViewModel
            {
                Id = model.Id,
                Date = model.Date,
                IsActive = model.IsActive
            };
        }
        public static List<AvailableDateViewModel> ToViewModelList(this IEnumerable<AvailableDate> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();
        }
    }
}
