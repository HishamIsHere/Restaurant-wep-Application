using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class TitlesMappingExtension
    {
        public static Titles ToModel(this TitlesViewModel model)
        {
            return new Titles
            {
                IsActive = model.IsActive,
                Id = model.Id,
                Title = model.Title,
                TitleDesc = model.TitleDesc,
                TitleKeyword = model.TitleKeyword,
            };

        }
        public static TitlesViewModel ToViewModel(this Titles model)
        {
            return new TitlesViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                Title = model.Title,
                TitleDesc = model.TitleDesc,
                TitleKeyword = model.TitleKeyword,
            };

        }
        public static List<TitlesViewModel> ToViewModelList(this List<Titles> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<Titles> ToViewModelList(this List<TitlesViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
