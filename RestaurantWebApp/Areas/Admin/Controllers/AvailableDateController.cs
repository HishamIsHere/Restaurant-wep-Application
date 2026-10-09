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
    public class AvailableDateController : Controller
    {
        IRepository<AvailableDate> Repository;

        public AvailableDateController(IRepository<AvailableDate> repository)
        {
            Repository = repository;
        }

        // GET: AvailableDateController
        public ActionResult Index()
        {
            var data = Repository.GetAll().ToViewModelList();
            var obj = new AvailableDateFullViewModel { List = data };
            return View(obj);
        }

        // POST: AvailableDateController/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(AvailableDateViewModel collection)
        {
            try
            {
                if (collection.Id == 0)
                {
                    var data = collection.ToModel();
                    data.CreatedBy = User.Identity?.Name;
                    Repository.Add(data);
                }
                else
                {
                    var data = collection.ToModel();
                    data.UpdatedBy = User.Identity?.Name;
                    Repository.Update(data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Redirect back to Index on error to avoid view model mismatch
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: AvailableDateController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AvailableDateFullViewModel collection)
        {
            try
            {
                Repository.Delete(collection.DeleteId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
