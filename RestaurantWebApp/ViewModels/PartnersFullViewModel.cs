using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class PartnersFullViewModel
    {
        public int Id { get; set; }
        public int DeleteId { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Partner Image")]
        public string PartnersImageURL { get; set; } = string.Empty;
        [Display(Name = "Alternate Image")]
        public string PartnersAltImageURL { get; set; } = string.Empty;
        [Display(Name = "Partner Link")]
        public string PartnersLink { get; set; } = string.Empty;
        public IFormFile? PartnersImageFile { get; set; }
        public IFormFile? PartnersAltFile { get; set; }
        public List<PartnersViewModel>? List { get; set; }
    }
}
