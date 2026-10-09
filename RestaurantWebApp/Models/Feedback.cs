using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class Feedback : BaseEntity
    {
        public string FeedbackDesc { get; set; } = string.Empty;
        public string FeedbackName { get; set; } = string.Empty;
        public string FeedbackImageURL { get; set; } = string.Empty;
        public string FeedbackTitle { get; set; } = string.Empty;

    }
}
