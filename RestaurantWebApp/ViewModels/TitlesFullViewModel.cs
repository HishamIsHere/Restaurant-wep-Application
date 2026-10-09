using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp22092026.ViewModels
{
    public class TitlesFullViewModel
    {
        public int Id { get; set; }
        public int DeleteId { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Title Text")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = "Title Description")]
        public string TitleDesc { get; set; } = string.Empty;
        [Display(Name = "Title Keyword")]
        public string TitleKeyword { get; set; } = string.Empty;
        public List<TitlesViewModel>? List { get; set; }
    }
}
