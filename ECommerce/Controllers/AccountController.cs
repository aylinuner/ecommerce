using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
