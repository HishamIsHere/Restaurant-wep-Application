using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class FeedbackMappingExtension
    {
        public static Feedback ToModel(this FeedbackViewModel model)
        {
            return new Feedback
            {
                IsActive = model.IsActive,
                Id = model.Id,
                FeedbackImageURL = model.FeedbackImageURL,
                FeedbackTitle = model.FeedbackTitle,
                FeedbackName = model.FeedbackName,
                FeedbackDesc = model.FeedbackDesc,
            };

        }
        public static FeedbackViewModel ToViewModel(this Feedback model)
        {
            return new FeedbackViewModel
            {
                IsActive = model.IsActive,
                Id = model.Id,
                FeedbackImageURL = model.FeedbackImageURL,
                FeedbackTitle = model.FeedbackTitle,
                FeedbackName = model.FeedbackName,
                FeedbackDesc = model.FeedbackDesc,
            };

        }
        public static List<FeedbackViewModel> ToViewModelList(this List<Feedback> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();

        }
        public static List<Feedback> ToViewModelList(this List<FeedbackViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();

        }
    }
}
