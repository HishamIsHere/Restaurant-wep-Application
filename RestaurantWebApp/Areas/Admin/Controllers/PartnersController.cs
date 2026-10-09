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
    public class PartnersController : Controller
    {
        IRepository<Partners> Repository;
        IFileHelper FileHelper;
        public PartnersController(IRepository<Partners> repository, IFileHelper fileHelper)
        {
            Repository = repository;
            FileHelper = fileHelper;
        }

        // GET: PartnersController
        public ActionResult Index()
        {
            var data = Repository.GetAll().ToViewModelList();
            var obj = new PartnersFullViewModel { List = data };
            return View(obj);
        }


        // POST: PartnersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(PartnersViewModel collection)
        {
            try
            {
                if (collection.Id == 0)
                {
                    var data = collection.ToModel();
                    data.CreatedBy = User.Identity?.Name;
                    data.PartnersImageURL = FileHelper.SaveImage(collection.PartnersImageFile, "PartnersImages");
                    data.PartnersAltImageURL = FileHelper.SaveImage(collection.PartnersAltFile, "PartnersImages");
                    if (data.PartnersImageURL != "Error")
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
                    data.PartnersImageURL = FileHelper.SaveImage(collection.PartnersImageFile, "PartnersImages");
                    data.PartnersAltImageURL = FileHelper.SaveImage(collection.PartnersAltFile, "PartnersImages");
                    if (data.PartnersImageURL != "Error")
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



        // POST: PartnersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PartnersFullViewModel collection)
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
