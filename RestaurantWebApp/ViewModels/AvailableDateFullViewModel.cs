using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class AvailableDateFullViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a date and time.")]
        [Display(Name = "Date and Time")]
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public string FormattedDate => Date.ToString("dd MMM yyyy - h:mm tt");
        public List<AvailableDateViewModel> List { get; set; } = new();
        public AvailableDateViewModel SingleItem { get; set; } = new();
        public int DeleteId { get; set; }
    }
}
