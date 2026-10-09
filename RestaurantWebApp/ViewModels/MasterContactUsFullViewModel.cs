using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class MasterContactUsFullViewModel
    {
        public int Id { get; set; }
        public int DeleteId { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Contact field icon")]
        public string MasterContactUsIcon { get; set; } = string.Empty;
        [Display(Name = "Contact body")]
        public string MasterContactUsText { get; set; } = string.Empty;
        [Display(Name = "Contact link")]
        public string MasterContactUsLink { get; set; } = string.Empty;
        public List<MasterContactUsViewModel>? List { get; set; }
    }
}
