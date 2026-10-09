using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class OpeningTimeFullViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int DeleteId { get; set; }
        [Display(Name = "Day")]
        [Required(ErrorMessage = "a Day is required")]
        public string OpeningTimeDay { get; set; } = string.Empty;
        [Display(Name = "Opening time")]
        [Required(ErrorMessage = "Correct opening time required")]
        public TimeSpan OpeningTimeStartTime { get; set; }
        [Display(Name = "Closing time")]
        [Required(ErrorMessage = "Correct closing time required")]
        public TimeSpan OpeningTimeEndTime { get; set; }
        public bool IsOpen { get; set; }
        public List<OpeningTimeViewModel>? List { get; set; }
        public string FormattedOpeningTimeStartTime => DateTime.Today.Add(OpeningTimeStartTime).ToString("h:mm tt");
        public string FormattedOpeningTimeEndTime => DateTime.Today.Add(OpeningTimeEndTime).ToString("h:mm tt");
    }
}
