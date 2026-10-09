using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class AvailableDate : BaseEntity
    {
        public DateTime Date { get; set; }

        public string FormattedDate => Date.ToString("d MMM - ") + Date.ToString("h.mmtt").ToLower();
    }
}
