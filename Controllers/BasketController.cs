using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class BasketController : Controller
    {
        private readonly EcommerceDbContext _context;

        public BasketController(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Veritabanından ürünleri çek
            try
            {
                List<basket> baskets = await _context.baskets.OrderBy(x => x.id).ToListAsync();
                ViewBag.basket = baskets;
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

