using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class FeedbackFullViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int DeleteId { get; set; }
        [Display(Name = "Client Name")]
        public string FeedbackName { get; set; } = string.Empty;
        [Display(Name = "Client Position")]
        public string FeedbackTitle { get; set; } = string.Empty;
        [Display(Name = "Feedback Description")]
        public string FeedbackDesc { get; set; } = string.Empty;
        [Display(Name = "Client Image")]
        public string FeedbackImageURL { get; set; } = string.Empty;
        public IFormFile? FeedbackImageFile { get; set; }
        public List<FeedbackViewModel>? List { get; set; }
    }
}
