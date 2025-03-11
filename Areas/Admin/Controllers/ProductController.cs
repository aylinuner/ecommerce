using ecommerce.Areas.Admin.Models;
using ecommerce.Areas.Admin.Models.View;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//sayfada kullanılan kodların ait olduğu kütüphaneler yukarıdaki gibi sayfaya dahil edilir.

namespace ecommerce.Areas.Admin.Controllers
{
[Area("Admin")]

    public class ProductController : Controller
    //Controller'dan Product Controller'a miras verdik. (Yani Controller'ı soyadı gibi düşün.
    //O soyadına sahip olunca bütün her şeyden yararlanabiliyosun.

    {

        #region dipendency injection(DI)
        private readonly EcommerceDbContext _context;

        public ProductController(EcommerceDbContext context)
        {
            _context = context;
        }
        #endregion
        [HttpGet]
        //Sayfa ilk açıldığında HttpGet özelliğiyle açılıyor. (Verileri getir demek.)
        public async Task<IActionResult> Index()
        //Index üzerine sağ tıklayıp go to view basınca bağlı olduğu view'a gidiyor.

        {
            // Veritabanından ürünleri çek
            try
            {
                List<product> products = await _context.products.OrderByDescending(x => x.id).ToListAsync();
                ViewBag.products = products;
            }
            catch (Exception x)
            {

                throw;
            }

            // Ürün listesini View'e gönder
            return View();
        }
        [HttpGet]

        public async Task <IActionResult> Save(int id)
        {
            ProductViewModel model = new ProductViewModel();
             
            
            if (id >0 )
            {

                product p = _context.products.FirstOrDefault(x => x.id == id);
                model.name =p.name;
                model.price = p.price;
                model.description = p.description;
                model.id = id;
            }
            return View(model);
        }
        [HttpPost]
        //Eğer sayfaya herhangi bir şey kaydetme işlemi olacaksa HttpPost kullanarak gönderme işlemi yapıyoruz.
        public IActionResult Save(ProductViewModel data)
        {
            //Eğer id yoksa yani yeni kayıt ise
            //if (data.id==0)
            //{

            //}
            //viewModel'den entity class'a veri aktarımı.
            product p = new product();
            p.name = data.name;
            p.description = data.description;
            p.price = data.price;
            p.create_date = DateTime.Now;
            p.id = data.id;

            //product entity'sini veritabanına kaydetme.
            if (p.id==0 )
            {
                _context.products.Add(p);//Veritabanındaki ürünler tablasona ekle.

            }
            else
            {
                _context.products.Update(p);//Veritabanındaki ürünü güncellet.

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
            
        }
        [HttpGet]
        public IActionResult Delete(int id)//parametre
        {
            product p = _context.products.FirstOrDefault(x => x.id == id);
            _context.products.Remove(p);
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
        public IActionResult List()
        {
            return View();
        }
    }
}