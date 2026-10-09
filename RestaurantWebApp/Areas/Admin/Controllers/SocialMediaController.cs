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
    public class SocialMediaController : Controller
    {
        IRepository<SocialMedia> Repository;

        public SocialMediaController(IRepository<SocialMedia> repository)
        {
            Repository = repository;
        }

        // GET: SocialMediaController
        public ActionResult Index()
        {
            var data = Repository.GetAll().ToViewModelList();
            var obj = new SocialMediaFullViewModel { List = data };
            return View(obj);
        }

        // POST: SocialMediaController/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(SocialMediaViewModel collection)
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
                return View();
            }
        }

        // POST: SocialMediaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SocialMediaFullViewModel collection)
        {
            try
            {
                Repository.Delete(collection.DeleteId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
