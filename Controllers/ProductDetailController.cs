using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
