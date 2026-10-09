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
    public class MenuItemsController : Controller
    {
        private readonly IRepository<MenuItems> _menuItemsRepository;
        private readonly IRepository<MenuCategory> _menuCategoryRepository;
        private readonly IFileHelper _fileHelper;

        public MenuItemsController(
            IRepository<MenuItems> menuItemsRepository,
            IRepository<MenuCategory> menuCategoryRepository,
            IFileHelper fileHelper)
        {
            _menuItemsRepository = menuItemsRepository;
            _menuCategoryRepository = menuCategoryRepository;
            _fileHelper = fileHelper;
        }

        // GET: Admin/MenuItems
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _menuCategoryRepository.GetAll().ToList();
            var items = _menuItemsRepository.GetAll().ToViewModelList();

            // Attach Category Names to the list items
            foreach (var item in items)
            {
                item.MenuCategoryName = categories
                    .FirstOrDefault(c => c.Id == item.MenuCategoryId)?.MenuCategoryName;
            }

            var model = new MenuItemsFullViewModel
            {
                List = items,
                MenuCategoryList = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.MenuCategoryName
                }).ToList()
            };

            return View(model);
        }

        // POST: Admin/MenuItems/CreateOrUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrUpdate(MenuItemsViewModel collection)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill in all required fields.";
                return RedirectToAction(nameof(Index));
            }

            var data = collection.ToModel();

            // Save new image if uploaded
            if (collection.MenuItemsImageFile != null)
            {
                string imagePath = _fileHelper.SaveImage(collection.MenuItemsImageFile, "MenuItemsImage");
                if (imagePath != "Error")
                {
                    data.MenuItemsImageURL = imagePath;
                }
            }

            if (data.Id == 0)
            {
                data.CreatedBy = User.Identity?.Name;
                _menuItemsRepository.Add(data);
                TempData["Success"] = "Menu item added successfully!";
            }
            else
            {
                data.UpdatedBy = User.Identity?.Name;
                _menuItemsRepository.Update(data);
                TempData["Success"] = "Menu item updated successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/MenuItems/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(MenuItemsFullViewModel collection)
        {
            if (collection.DeleteId > 0)
            {
                _menuItemsRepository.Delete(collection.DeleteId);
                TempData["Success"] = "Menu item deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
