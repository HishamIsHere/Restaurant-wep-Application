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
    public class SliderController : Controller
    {
        IRepository<Slider> Repository;
        IFileHelper FileHelper;
        public SliderController(IRepository<Slider> repository, IFileHelper fileHelper)
        {
            Repository = repository;
            FileHelper = fileHelper;
        }

        // GET: SliderController
        public ActionResult Index()
        {
            var data = Repository.GetAll().ToViewModelList();
            var obj = new SliderFullViewModel { List = data };
            return View(obj);
        }


        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(SliderViewModel collection)
        {
            try
            {
                if (collection.Id == 0)
                {
                    var data = collection.ToModel();
                    data.CreatedBy = User.Identity?.Name;
                    data.SliderImageURL = FileHelper.SaveImage(collection.SliderImageFile, "SliderImages");
                    if (data.SliderImageURL != "Error")
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
                    data.SliderImageURL = FileHelper.SaveImage(collection.SliderImageFile, "SliderImages");
                    if (data.SliderImageURL != "Error")
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



        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SliderFullViewModel collection)
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
