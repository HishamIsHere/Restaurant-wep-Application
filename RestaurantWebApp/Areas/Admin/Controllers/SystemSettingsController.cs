using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantWebApp22092026.Extensions;
using RestaurantWebApp22092026.Models;
using RestaurantWebApp22092026.ViewModels;
using WebAppTemplate.Helpers.File;
using WebAppTemplate.Repositories;

namespace RestaurantWebApp22092026.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SystemSettingsController : Controller
    {
        IRepository<SystemSettings> Repository;
        IFileHelper FileHelper;
        public SystemSettingsController(IRepository<SystemSettings> repository, IFileHelper fileHelper)
        {
            Repository = repository;
            FileHelper = fileHelper;
        }

        // GET: SystemSettingsController
        public ActionResult Index()
        {
            var data = Repository.GetAll().ToViewModelList();
            var obj = new SystemSettingsFullViewModel { List = data };
            return View(obj);
        }


        // POST: SystemSettingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(SystemSettingsViewModel collection)
        {
            try
            {
                if (collection.Id == 0)
                {
                    var data = collection.ToModel();
                    data.CreatedBy = User.Identity?.Name;
                    data.LogoDarkURL = FileHelper.SaveImage(collection.LogoDarkFile, "SystemSettingsImages");
                    data.LogoLightURL = FileHelper.SaveImage(collection.LogoLightFile, "SystemSettingsImages");
                    data.SliderBackgroundURL = FileHelper.SaveImage(collection.SliderBackgroundFile, "SystemSettingsImages");
                    data.PopularBackgroundURL = FileHelper.SaveImage(collection.PopularBackgroundFile, "SystemSettingsImages");
                    data.ReservationImageURL = FileHelper.SaveImage(collection.ReservationImageFile, "SystemSettingsImages");
                    if (data.LogoDarkURL != "Error" || data.LogoLightURL != "Error" || data.SliderBackgroundURL != "Error" || data.PopularBackgroundURL != "Error" || data.ReservationImageURL != "Error")
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
                    data.LogoDarkURL = FileHelper.SaveImage(collection.LogoDarkFile, "SystemSettingsImages");
                    data.LogoLightURL = FileHelper.SaveImage(collection.LogoLightFile, "SystemSettingsImages");
                    data.SliderBackgroundURL = FileHelper.SaveImage(collection.SliderBackgroundFile, "SystemSettingsImages");
                    data.PopularBackgroundURL = FileHelper.SaveImage(collection.PopularBackgroundFile, "SystemSettingsImages");
                    data.ReservationImageURL = FileHelper.SaveImage(collection.ReservationImageFile, "SystemSettingsImages");
                    if (data.LogoDarkURL != "Error" || data.LogoLightURL != "Error" || data.SliderBackgroundURL != "Error" || data.PopularBackgroundURL != "Error" || data.ReservationImageURL != "Error")
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



        // POST: SystemSettingsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SystemSettingsFullViewModel collection)
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
