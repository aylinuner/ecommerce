using ecommerce.Models;
using ecommerce.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly _DbContext _context;

        public ProductController(_DbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Veritabanından ürünleri çek
            try
            {
                List<StockMaster> stocks = await _context.StockMaster.OrderBy(x => x.Id).ToListAsync();
                ViewBag.products = stocks;
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
