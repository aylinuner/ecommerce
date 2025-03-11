using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
