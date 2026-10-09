using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class AboutFullViewModel
    {
        public int Id { get; set; }
        public int DeleteId { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "About Title")]
        public string AboutTitle { get; set; } = string.Empty;
        [Display(Name = "About Brief")]
        public string AboutBrief { get; set; } = string.Empty;
        [Display(Name = "About Description")]
        public string AboutDesc { get; set; } = string.Empty;
        [Display(Name = "About Image")]
        public string AboutImageURL { get; set; } = string.Empty;
        public IFormFile? AboutImageFile { get; set; }
        [Display(Name = "About footer description")]
        public string AboutFooterDesc { get; set; } = string.Empty;
        public List<AboutViewModel>? List { get; set; }
    }
}
