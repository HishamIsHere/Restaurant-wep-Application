using WebAppTemplate.Models;

namespace RestaurantWebApp22092026.Models
{
    public class OpeningTime : BaseEntity
    {
        public string OpeningTimeDay { get; set; } = string.Empty;
        public TimeSpan OpeningTimeStartTime { get; set; }
        public TimeSpan OpeningTimeEndTime { get; set; }
        public bool IsOpen { get; set; }
    }
}
