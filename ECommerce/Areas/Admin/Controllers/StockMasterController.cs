using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Areas.Admin.Controllers
{
    public class StockMasterController : Controller
    {
        public IActionResult Index()
        {
              // Veritabanından ürünleri çek
            try
            {
                //List<Product> products = await _context.Product.OrderBy(x => x.Id).ToListAsync();
                //ViewBag.products = products;
            }
            catch (Exception x)
            {

                throw;
            }

            // Ürün listesini View'e gönder
            return View();
        }
    }
}
