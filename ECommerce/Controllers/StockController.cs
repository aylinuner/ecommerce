using ecommerce.Models;
using ecommerce.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class StockController : Controller
    {
        private readonly _DbContext _context;

        public StockController(_DbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Veritabanından ürünleri çek
            try
            {
                List<StockMaster> stocks = await _context.StockMaster.OrderBy(x => x.Id).ToListAsync();
                ViewBag.stocks = stocks;
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
