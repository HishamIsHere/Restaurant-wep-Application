using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppTemplate.ViewModels;

namespace SecondWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
        //Async ==> Task ==> Await
        // {
        // *- get data
        // *- add data
        // *- update data
        // }



        // User Management
        // sign in management

        UserManager<IdentityUser> UserManager;
        SignInManager<IdentityUser> SignInManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Login() // ViewModel
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model) // ViewModel
        {
            var user = await UserManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                var result = await SignInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Home");   
                }
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() // ViewModel
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        [AllowAnonymous]
        public IActionResult Register() // ViewModel
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) // ViewModel
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Password and Confirmation must be matched.");
                return View(model);
            }
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Username,
            };
            var result = await UserManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction(nameof(Login));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
    }
}
