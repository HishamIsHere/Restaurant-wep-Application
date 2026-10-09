using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class ServicesFullViewModel
    {
        public int Id { get; set; }
        public int DeleteId { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Service title")]
        public string ServicesTitle { get; set; } = string.Empty;
        [Display(Name = "Service description")]
        public string ServicesDesc { get; set; } = string.Empty;
        [Display(Name = "Service icon")]
        public string ServicesIcon { get; set; } = string.Empty;
        public List<ServicesViewModel>? List { get; set; }
    }
}
