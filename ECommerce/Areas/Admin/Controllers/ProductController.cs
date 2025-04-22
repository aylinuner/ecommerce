//using ecommerce.Models;
//using ecommerce.Models.Db;
//using ecommerce.Models.View;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
////sayfada kullanılan kodların ait olduğu kütüphaneler yukarıdaki gibi sayfaya dahil edilir.

//namespace ecommerce.Areas.Admin.Controllers
//{
//    [Area("Admin")]

//    [Authorize(Roles = "Admin")]


//    public class ProductController : Controller
//    //Controller'dan Product Controller'a miras verdik. (Yani Controller'ı soyadı gibi düşün.
//    //O soyadına sahip olunca bütün her şeyden yararlanabiliyosun.

//    {
//        #region dipendency injection(DI)
//        private readonly _DbContext _context;

//        public ProductController(_DbContext context)
//        {
//            _context = context;
//        }
//        #endregion
//        [HttpGet]
//        //Sayfa ilk açıldığında HttpGet özelliğiyle açılıyor. (Verileri getir demek.)
//        public async Task<IActionResult> Index()
//        //Index üzerine sağ tıklayıp go to view basınca bağlı olduğu view'a gidiyor.

//        {
//            // Veritabanından ürünleri çek
//            try
//            {
//                List<Product> products = await _context.Product.OrderBy(x => x.Id).ToListAsync();
//                ViewBag.products = products;
//            }
//            catch (Exception x)
//            {

//                throw;
//            }

//            // Ürün listesini View'e gönder
//            return View();
//        }
//        [HttpGet]

//        public async Task<IActionResult> Save(int Id)
//        {
//            ProductViewModel model = new ProductViewModel();

//            if (Id > 0)
//            {
//                Product p = _context.Product.FirstOrDefault(x => x.Id == Id);
//                if (p != null) // Eğer kayıt bulunursa
//                {
//                    model.Name = p.Name;
//                    model.Price = (int)p.Price;
//                    model.Description = p.Description;
//                    model.Id = Id;
//                }

//            }
//            return View(model);
//        }
//        [HttpPost]
//        //Eğer sayfaya herhangi bir şey kaydetme işlemi olacaksa HttpPost kullanarak gönderme işlemi yapıyoruz.
//        public IActionResult Save(ProductViewModel data)
//        {
//            //Eğer id yoksa yani yeni kayıt ise
//            //if (data.id==0)
//            //{

//            //}
//            //viewModel'den entity class'a veri aktarımı.
//            Product p = new Product();
//            p.Name = data.Name;
//            p.Description = data.Description;
//            p.Price = data.Price;
//            p.CreateDate = DateTime.Now;
//            p.Id = data.Id;

//            //product entity'sini veritabanına kaydetme.
//            if (p.Id == 0)
//            {
//                _context.Product.Add(p);//Veritabanındaki ürünler tablasona ekle.

//            }
//            else
//            {
//                _context.Product.Update(p);//Veritabanındaki ürünü güncellet.

//            }
//            _context.SaveChanges();

//            return RedirectToAction("Index", "Product");

//        }
//        [HttpGet]
//        public IActionResult Delete(int Id)//parametre
//        {
//            Product p = _context.Product.FirstOrDefault(x => x.Id == Id);
//            _context.Product.Remove(p);
//            _context.SaveChanges();

//            return RedirectToAction("Index", "Product");
//        }
//        public IActionResult List()
//        {
//            return View();
//        }
//    }
//}