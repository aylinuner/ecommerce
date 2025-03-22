using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class OrderController : Controller
    {
        //Teslimat bilgileri sayfası
        public IActionResult Delivery()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
    }
}
