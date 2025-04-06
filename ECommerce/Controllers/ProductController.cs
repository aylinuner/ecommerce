//using ecommerce.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ecommerce.Controllers
//{
//    public class ProductController : Controller
//    {
//        private readonly _DbContext _context;

//        public ProductController(_DbContext context)
//        {
//            _context = context;
//        }
//        public async Task<IActionResult> Index()
//        {
//            // Veritabanından ürünleri çek
//            try
//            {
//                List<product> products = await _context.product.OrderBy(x => x.id).ToListAsync();
//                ViewBag.products = products;
//            }
//            catch (Exception x)
//            {

//                throw;
//            }

//            // Ürün listesini View'e gönder
//            return View();
//        }

//    }
//}
