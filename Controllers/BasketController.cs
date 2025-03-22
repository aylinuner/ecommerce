using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class BasketController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToBasket(int id)
        {
            // Ürün ID'siyle işlemleri gerçekleştir
            // Örneğin: Sepete ekle, session'a kaydet vs.

            return RedirectToAction("Index", "Basket"); // Sepet sayfasına yönlendirme
        }
    }

}
