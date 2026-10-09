using Microsoft.AspNetCore.Mvc;

namespace WebAppTemplate.Components
{
    public class UserInfoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("",User.Identity?.Name);
        }
    }
}
