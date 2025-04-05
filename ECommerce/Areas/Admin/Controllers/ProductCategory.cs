using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Areas.Admin.Controllers
{
    public class ProductCategory : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
