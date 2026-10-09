using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebApp22092026.Models;
using WebAppTemplate.Helpers.Email;
using WebAppTemplate.Repositories;
using WebAppTemplate.ViewModels;

namespace RestaurantWebApp22092026.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUsController : Controller
    {

        private readonly IRepository<TransactionContactUs> _repository;
        private readonly IEmailHelper _emailhelper;
        public TransactionContactUsController(IRepository<TransactionContactUs> repository, IEmailHelper emailhelper)
        {
            _repository = repository;
            _emailhelper = emailhelper;
        }

        // GET: TransactionContactUsController
        public ActionResult Index()
        {
            var messages = _repository.GetAll().OrderByDescending(m => m.SendingDate).ToList();
            return View(messages);
        }

        // GET: TransactionContactUsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionContactUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionContactUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionContactUsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionContactUsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reply(int id, string recipientEmail, string subject, string replymessage)
        {
            try
            {
                var EmailModel = new EmailViewModel
                {
                    EmailAddress = recipientEmail,
                    Subject = "Re: " + subject,
                    Message = replymessage
                };
                _emailhelper.SendMessage(EmailModel);
                var entity = _repository.GetAll().FirstOrDefault(x => x.Id == id);
                if(entity != null)
                {
                    entity.IsReplied = true;
                    _repository.Update(entity);
                }
                TempData["Success"] = "Reply sent successfully!";
            }
            catch
            {
                TempData["Error"] = "Failed to send email: ";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
