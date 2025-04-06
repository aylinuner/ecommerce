//using ecommerce.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using NuGet.ContentModel;

//namespace ecommerce.Controllers
//{
//    public class BasketController : Controller
//    {
//        private readonly _DbContext _context;

//        public BasketController(_DbContext context)
//        {
//            _context = context;
//        }
//        public async Task<IActionResult> Index()
//        {
//            try
//            {
//                // Sepet verilerini çekerken User ve Product tablolarını dahil et
//                List<basket> baskets = await _context.basket
//                    //.Include(u => u.user)  // User tablosunu dahil et
//                    .Include(p => p.product)  // Product tablosunu dahil et
//                    .OrderBy(x => x.id)
//                    .ToListAsync();

//                ViewBag.baskets = baskets;
//            }
//            catch (Exception ex)
//            {
//                // Hata yönetimi için loglama ekleyebilirsin
//                Console.WriteLine(ex.Message);
//                throw;
//            }

//            // Ürün listesini View'e gönder
//            return View();
//        }

//    }
//}

