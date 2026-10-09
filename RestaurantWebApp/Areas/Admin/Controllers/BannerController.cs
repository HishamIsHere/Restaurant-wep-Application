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
    public class BannerController : Controller
    {
        IRepository<Banner> Repository;
        IFileHelper FileHelper;
        public BannerController(IRepository<Banner> repository, IFileHelper fileHelper)
        {
            Repository = repository;
            FileHelper = fileHelper;
        }

        // GET: BannerController
        public ActionResult Index()
        {
            var data = Repository.GetAll().ToViewModelList();
            var obj = new BannerFullViewModel { List = data };
            return View(obj);
        }


        // POST: BannerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(BannerViewModel collection)
        {
            try
            {
                var allData = Repository.GetAll();
                if (collection.BannerIsPrimary && allData.Any(x => x.BannerIsPrimary && x.Id != collection.Id))
                {
                    TempData["ErrorMessage"] = "Only one banner is allowed to be primary.";
                    return RedirectToAction(nameof(Index));
                }


                if (collection.Id == 0)
                    {
                        var data = collection.ToModel();
                        data.CreatedBy = User.Identity?.Name;
                        data.BannerImageURL = FileHelper.SaveImage(collection.BannerImageFile, "BannerImages");
                        if (data.BannerImageURL != "Error")
                        {
                            Repository.Add(data);
                        }
                        else
                        {
                            ModelState.AddModelError("", "Image Is Required");
                            return View(collection);
                        }
                    }
                    else
                    {
                        var data = collection.ToModel();
                        data.UpdatedBy = User.Identity?.Name;
                        data.BannerImageURL = FileHelper.SaveImage(collection.BannerImageFile, "BannerImages");
                        if (data.BannerImageURL != "Error")
                        {
                            Repository.Update(data);
                        }
                        else
                        {
                            ModelState.AddModelError("", "Image Is Required");
                            return View(collection);
                        }
                    }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // POST: BannerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BannerFullViewModel collection)
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
