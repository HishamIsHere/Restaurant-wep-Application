using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class AvailableDateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a date and time.")]
        [Display(Name = "Date and Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = new DateTime(
            DateTime.Now.Year,
            DateTime.Now.Month,
            DateTime.Now.Day,
            DateTime.Now.Hour,
            DateTime.Now.Minute,
            0
        );

        public bool IsActive { get; set; } = true;

        public string FormattedDate => Date.ToString("dd MMM yyyy - h:mm tt");
    }
}
