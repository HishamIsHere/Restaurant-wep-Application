using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantWebApp22092026.Extensions;
using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;
using System.Diagnostics;
using WebAppTemplate.Helpers.Email;
using WebAppTemplate.Models;
using WebAppTemplate.Repositories;
using WebAppTemplate.ViewModels;

namespace WebAppTemplate.Controllers
{
    public class HomeController : Controller
    {
        IRepository<SystemSettings> SystemSettingsRepository;
        IRepository<Slider> SliderRepository;
        IRepository<About> AboutRepository;
        IRepository<Titles> TitlesRepository;
        IRepository<Feedback> FeedBackRepository;
        IRepository<Banner> BannerRepository;
        IRepository<Partners> PartnersRepository;
        IRepository<SocialMedia> SocialMediaRepository;
        IRepository<MasterContactUs> MasterContactUsRepository;
        IRepository<OpeningTime> OpeningTimeRepository;
        IRepository<Services> ServicesRepository;
        IRepository<MenuCategory> MenuCategoryRepository;
        IRepository<MenuItems> MenuItemsRepository;
        IRepository<TransactionContactUs> TransactionContactUsRepository;
        IRepository<TransactionNewsLetter> TransactionNewsLetterRepository;
        IRepository<AvailableDate> AvailableDateRepository;
        IRepository<TransactionReservation> TransactionReservationRepository;
        IEmailHelper EmailHelper;
        public HomeController(IRepository<SystemSettings> systemSettingsRepository, IRepository<Slider> sliderRepository, IRepository<About> aboutRepository, IRepository<Titles> titlesRepository, IRepository<Feedback> feedBackRepository, IRepository<Banner> bannerRepository, IRepository<Partners> partnersRepository, IRepository<SocialMedia> socialMediaRepository, IRepository<MasterContactUs> masterContactUsRepository, IRepository<OpeningTime> openingTimeRepository, IRepository<Services> servicesRepository, IRepository<MenuCategory> menuCategoryRepository, IRepository<MenuItems> menuItemsRepository, IRepository<TransactionContactUs> transactionContactUsRepository, IRepository<TransactionNewsLetter> transactionNewsLetterRepository, IRepository<AvailableDate> availableDateRepository, IRepository<TransactionReservation> transactionReservationRepository, IEmailHelper emailHelper)
        {
            SystemSettingsRepository = systemSettingsRepository;
            SliderRepository = sliderRepository;
            AboutRepository = aboutRepository;
            TitlesRepository = titlesRepository;
            FeedBackRepository = feedBackRepository;
            BannerRepository = bannerRepository;
            PartnersRepository = partnersRepository;
            SocialMediaRepository = socialMediaRepository;
            MasterContactUsRepository = masterContactUsRepository;
            OpeningTimeRepository = openingTimeRepository;
            ServicesRepository = servicesRepository;
            MenuCategoryRepository = menuCategoryRepository;
            MenuItemsRepository = menuItemsRepository;
            TransactionContactUsRepository = transactionContactUsRepository;
            TransactionNewsLetterRepository = transactionNewsLetterRepository;
            AvailableDateRepository = availableDateRepository;
            TransactionReservationRepository = transactionReservationRepository;
            EmailHelper = emailHelper;
        }

        public HomeViewModel GetData()
        {
            var data = new HomeViewModel
            {
                SystemSettings = SystemSettingsRepository.GetAllClient()?.FirstOrDefault()?.ToViewModel(),
                Slider = SliderRepository.GetAllClient()?.ToViewModelList(),
                Titles = TitlesRepository.GetAllClient()?.ToViewModelList(),
                Feedback = FeedBackRepository.GetAllClient()?.ToViewModelList(),
                About = AboutRepository.GetAllClient()?.ToViewModelList(),
                Banner = BannerRepository.GetAllClient()?.FirstOrDefault()?.ToViewModel(),
                Partners = PartnersRepository.GetAllClient().ToViewModelList(),
                SocialMedia = SocialMediaRepository.GetAllClient().ToViewModelList(),
                MasterContactUs = MasterContactUsRepository.GetAllClient().ToViewModelList(),
                OpeningTime = OpeningTimeRepository.GetAllClient().ToViewModelList(),
                Services = ServicesRepository.GetAllClient().ToViewModelList(),
                MenuCategory = MenuCategoryRepository.GetAllClient().ToViewModelList(),
                MenuItems = MenuItemsRepository.GetAllClient().ToViewModelList(),
                TransactionReservation = new TransactionReservationViewModel(),
                AvailableDates = AvailableDateRepository.GetAllClient()?.ToViewModelList() ?? new()
            };
            return data;
        }
        public IActionResult Index()
        {
            var HomeModel = GetData();
            return View(HomeModel);
        }

        public IActionResult Privacy()
        {
            var model = GetData();
            return View("Privacy",model);
        }
        public IActionResult AboutUs()
        {
            var model = GetData();
            return View("about-us", model);
        }
        public IActionResult Menu()
        {
            var model = GetData();
            return View("menu", model);
        }
        public IActionResult ContactUs()
        {
            var model = GetData();
            return View("contact",model);
        }
        public IActionResult ProductDetails()
        {
            var model = GetData();
            return View("product-details",model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SendContactMessage(TransactionContactUs model)
        {
            if (ModelState.IsValid)
            {
                model.SendingDate = DateTime.UtcNow;
                model.IsReplied = false;
                TransactionContactUsRepository.Add(model);
                TempData["Success"] = "Your message has been sent successfully!";
                return RedirectToAction(nameof(ContactUs));
            }
            return RedirectToAction(nameof(ContactUs));
        }
        public IActionResult SubscribeNewsletter(string Email)
        {
            var exists = TransactionNewsLetterRepository.GetAll().FirstOrDefault(x => x.Email.ToLower() == Email.ToLower());
            if (exists == null)
            {
                var subscriber = new TransactionNewsLetter
                {
                    Email = Email,
                    SendingDate = DateTime.UtcNow,
                    IsActive = true
                };
                TransactionNewsLetterRepository.Add(subscriber);
                
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reserve([Bind(Prefix = "TransactionReservation")] TransactionReservationViewModel model)

        {
            if (ModelState.IsValid)
            {
                var entity = model.ToModel();
                entity.IsActive = true;
                entity.CreatedBy = User.Identity?.Name ?? "Guest";
                TransactionReservationRepository.Add(entity);
                var dateEntity = AvailableDateRepository.GetById(model.AvailableDateId);
                string reservationTime = dateEntity != null
                ? dateEntity.Date.ToString("dd MMM yyyy - h:mm tt")
                : "N/A";
                AvailableDateRepository.ChangeStatus(model.AvailableDateId);
                try
                {
                    var emailModel = new EmailViewModel
                    {
                        EmailAddress = model.EmailAddress,
                        Subject = "Reservation Confirmation - Restaurant",
                        Message = $@" <h3>Dear {model.FullName},</h3> <p>Thank you for choosing our restaurant! Your reservation has been placed successfully.</p> <p><strong>Reservation Date & Time:</strong> {reservationTime}</p> <p><strong>Contact Mobile:</strong> {model.MobileNumber}</p> <br/> <p>We look forward to welcoming you!</p>"
                    };
                    EmailHelper.SendMessage(emailModel);
                }
                catch
                {

                }
                TempData["SuccessMessage"] = "Your reservation has been placed successfully! Check your email for confirmation.";
                return RedirectToAction(nameof(Index));
            }
            var reloadModel = GetData();
            reloadModel.TransactionReservation = model;
            return View("Index", reloadModel);
        }
    }
}
