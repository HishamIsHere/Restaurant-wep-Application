using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class SliderMappingExtension
    {
        public static Slider ToModel(this SliderViewModel model)
        {
            return new Slider
            {
                IsActive = model.IsActive,
                Id = model.Id,
                SliderImageURL = model.SliderImageURL,
                SliderTitle = model.SliderTitle,
                SliderBrief = model.SliderBrief,
                SliderDesc = model.SliderDesc,
            };

        }
        public static SliderViewModel ToViewModel(this Slider model)
        {
            return new SliderViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                SliderImageURL = model.SliderImageURL,
                SliderTitle = model.SliderTitle,
                SliderBrief = model.SliderBrief,
                SliderDesc = model.SliderDesc,
            };

        }
        public static List<SliderViewModel> ToViewModelList(this List<Slider> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<Slider> ToViewModelList(this List<SliderViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
