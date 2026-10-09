using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class OpeningTimeMappingExtension
    {
        public static OpeningTime ToModel(this OpeningTimeViewModel model)
        {
            return new OpeningTime
            {
                IsActive = model.IsActive,
                Id = model.Id,
                OpeningTimeDay = model.OpeningTimeDay,
                OpeningTimeStartTime = model.OpeningTimeStartTime,
                OpeningTimeEndTime = model.OpeningTimeEndTime,
                IsOpen = model.IsOpen,


            };

        }
        public static OpeningTimeViewModel ToViewModel(this OpeningTime model)
        {
            return new OpeningTimeViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                OpeningTimeDay = model.OpeningTimeDay,
                OpeningTimeStartTime = model.OpeningTimeStartTime,
                OpeningTimeEndTime = model.OpeningTimeEndTime,
                IsOpen = model.IsOpen,
            };

        }
        public static List<OpeningTimeViewModel> ToViewModelList(this List<OpeningTime> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<OpeningTime> ToViewModelList(this List<OpeningTimeViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
