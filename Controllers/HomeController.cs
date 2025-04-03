using System.Diagnostics;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly EcommerceDbContext _context;

        public HomeController(EcommerceDbContext context)
        {
            _context = context;
        }

       public async Task<IActionResult> Index()
        {
            // Veritabanýndan ürünleri çek
            try
            {
                List<home> homes = await _context.homes.OrderBy(x => x.id).ToListAsync();
                ViewBag.homes = homes;

                List<product> products = await _context.products.OrderBy(x => x.id).ToListAsync();
                ViewBag.products = products;
            }
            catch (Exception x)
            {

                throw;
            }

            // Ürün listesini View'e gönder
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
