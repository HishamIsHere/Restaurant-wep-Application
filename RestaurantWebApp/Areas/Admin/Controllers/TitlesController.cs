using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebApp22092026.Extensions;
using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;
using WebAppTemplate.Helpers.File;
using WebAppTemplate.Repositories;

namespace RestaurantWebApp22092026.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TitlesController : Controller
    {
        IRepository<Titles> Repository;

        public TitlesController(IRepository<Titles> repository)
        {
            Repository = repository;
        }

        // GET: TitlesController
        public ActionResult Index()
        {
            var data = Repository.GetAll().ToViewModelList();
            var obj = new TitlesFullViewModel { List = data };
            return View(obj);
        }

        // POST: TitlesController/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(TitlesViewModel collection)
        {
            try
            {
                var allData = Repository.GetAll();
                if (!string.IsNullOrEmpty(collection.TitleKeyword) && allData.Any(x => x.TitleKeyword == collection.TitleKeyword && x.Id != collection.Id))
                {
                    ModelState.AddModelError("", "Keyword already exists.");
                    return Json(new { success = false, message = "Keyword already exists." });
                }
                else
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
            }
            catch
            {
                return Json(new { success = false, message = "Keyword already exists." });
            }
        }

        // POST: TitlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TitlesFullViewModel collection)
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
