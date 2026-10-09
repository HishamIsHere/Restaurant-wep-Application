using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class ServicesViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [Display(Name ="Service title")]
        public string ServicesTitle { get; set; } = string.Empty;
        [Display(Name = "Service description")]
        public string ServicesDesc { get; set; } = string.Empty;
        [Display(Name = "Service icon")]
        public string ServicesIcon { get; set; } = string.Empty;
    }
}
