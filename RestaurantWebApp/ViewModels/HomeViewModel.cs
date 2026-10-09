using RestaurantWebApp22092026.Models;

namespace RestaurantWebApp22092026.ViewModels
{
    public class HomeViewModel
    {
        public SystemSettingsViewModel SystemSettings { get; set; }
        public List<SliderViewModel> Slider { get; set; }
        public List<TitlesViewModel> Titles { get; set; }
        public List<FeedbackViewModel> Feedback { get; set; }
        public List<AboutViewModel> About { get; set; }
        public BannerViewModel Banner { get; set; }
        public List<PartnersViewModel> Partners { get; set; }
        public List<SocialMediaViewModel> SocialMedia { get; set; }
        public List<MasterContactUsViewModel> MasterContactUs { get; set; }
        public List<OpeningTimeViewModel> OpeningTime { get; set; }
        public List<ServicesViewModel> Services { get; set; }
        public List<MenuItemsViewModel> MenuItems { get; set; }
        public List<MenuCategoryViewModel> MenuCategory { get; set; }
        public TransactionReservationViewModel TransactionReservation { get; set; } = new();
        public List<AvailableDateViewModel> AvailableDates { get; set; } = new();

    }
}
