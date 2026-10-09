using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class TransactionReservation : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public int AvailableDateId { get; set; }
        public AvailableDate? AvailableDate { get; set; }
    }
}
