using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class UserPanelController : Controller
    {
        public IActionResult Membership()
        {
            return View();
        }
        public IActionResult Order()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }

    }
}
