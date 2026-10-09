using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;

namespace RestaurantWebApp22092026.Extensions
{
    public static class TransactionReservationMappingExtension
    {
        public static TransactionReservation ToModel(this TransactionReservationViewModel model)
        {
            return new TransactionReservation
            {
                Id = model.Id,
                IsActive = model.IsActive,
                FullName = model.FullName,
                EmailAddress = model.EmailAddress,
                MobileNumber = model.MobileNumber,
                AvailableDateId = model.AvailableDateId
            };
        }
        public static TransactionReservationViewModel ToViewModel(this TransactionReservation model)
        {
            return new TransactionReservationViewModel
            {
                Id = model.Id,
                IsActive = model.IsActive,
                FullName = model.FullName,
                EmailAddress = model.EmailAddress,
                MobileNumber = model.MobileNumber,
                AvailableDateId = model.AvailableDateId
            };
        }
        public static List<TransactionReservationViewModel> ToViewModelList(this IEnumerable<TransactionReservation> model)
        {
            return model.Select(x => x.ToViewModel()).ToList();
        }
        public static List<TransactionReservation> ToModelList(this IEnumerable<TransactionReservationViewModel> model)
        {
            return model.Select(x => x.ToModel()).ToList();
        }
    }
}
