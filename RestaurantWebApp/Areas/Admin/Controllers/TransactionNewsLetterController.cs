using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using RestaurantWebApp22092026.Models;
using WebAppTemplate.Helpers.Email;
using WebAppTemplate.Repositories;
using WebAppTemplate.ViewModels;

namespace RestaurantWebApp22092026.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionNewsLetterController : Controller
    {

        private readonly IRepository<TransactionNewsLetter> _repository;
        private readonly IEmailHelper _emailhelper;
        public TransactionNewsLetterController(IRepository<TransactionNewsLetter> repository, IEmailHelper emailhelper)
        {
            _repository = repository;
            _emailhelper = emailhelper;
        }

        // GET: TransactionNewsLetterController
        public ActionResult Index()
        {
            var messages = _repository.GetAll().OrderByDescending(m => m.SendingDate).ToList();
            return View(messages);
        }

        // GET: TransactionNewsLetterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionNewsLetterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionNewsLetterController/Create
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

        // GET: TransactionNewsLetterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionNewsLetterController/Edit/5
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
                if (entity != null)
                {
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
        public IActionResult SendNewsLetter(string Subject, string MessageContect)
        {
            var Subsribers = _repository.GetAll().Where(x => x.IsActive).ToList();
            foreach (var sub in Subsribers) 
            {
                var EmailModel = new EmailViewModel
                {
                    EmailAddress = sub.Email,
                    Subject = Subject,
                    Message = MessageContect,

                };
                _emailhelper.SendMessage(EmailModel);
            }
            TempData["Success"] = $"Newsletter dispatched to {Subsribers.Count} subscribers.";
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var data = _repository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                data.IsActive = false;
                _repository.Update(data);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
