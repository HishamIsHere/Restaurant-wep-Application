using RestaurantWebApp22092026.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class TransactionReservationViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Mobile Number is required.")]
        public string MobileNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select a date and time.")]
        public int AvailableDateId { get; set; }
        public List<AvailableDate>? AvailableDates { get; set; }

        public string? ReservationDate { get; set; }
    }
}
