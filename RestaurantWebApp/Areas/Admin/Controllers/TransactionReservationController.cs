using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebApp22092026.Extensions;
using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;
using WebAppTemplate.Repositories;

namespace RestaurantWebApp22092026.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionReservationController : Controller
    {
        private readonly IRepository<TransactionReservation> _reservationRepository;
        private readonly IRepository<AvailableDate> _availableDateRepository;

        public TransactionReservationController(
            IRepository<TransactionReservation> reservationRepository,
            IRepository<AvailableDate> availableDateRepository)
        {
            _reservationRepository = reservationRepository;
            _availableDateRepository = availableDateRepository;
        }

        public IActionResult Index()
        {
            var reservations = _reservationRepository.GetAll();
            var datesDict = _availableDateRepository.GetAll().ToDictionary(d => d.Id);

            var viewModelList = reservations.Select(r =>
            {
                var vm = r.ToViewModel();
                if (datesDict.TryGetValue(r.AvailableDateId, out var dateEntity))
                {
                    vm.ReservationDate = dateEntity.Date.ToString("d MMM yyyy - ") + dateEntity.Date.ToString("h.mmtt").ToLower();
                }
                return vm;
            }).ToList();

            return View(viewModelList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int id)
        {
            var item = _reservationRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            item.IsActive = !item.IsActive;
            _reservationRepository.Update(item);

            TempData["SuccessMessage"] = item.IsActive ? "Reservation activated." : "Reservation deactivated.";
            return RedirectToAction(nameof(Index));
        }
    }
}
