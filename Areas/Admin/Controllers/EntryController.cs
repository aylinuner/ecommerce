using ecommerce.Areas.Admin.Models.View;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EntryController : Controller
    {
        private readonly EcommerceDbContext _context;
        public EntryController(EcommerceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Ürünleri veritabanından çek.
            try
            {
                List<entry_master> entry_masters = await _context.entry_masters.OrderBy(x => x.id).ToListAsync();
                ViewBag.entry_masters = entry_masters;
            }
            catch (Exception x)
            {
                throw;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            EntryViewModel model = new EntryViewModel();
            if (id > 0)
            {
                entry_master em = _context.entry_masters.FirstOrDefault(x => x.id == id);
                model.id = em.id;
                model.waybill_no = em.waybill_no;
                model.waybill_date = em.waybill_date;
                model.waybill_total = em.waybill_total;
                model.supplier = em.supplier;
                //product_id, category_name yazılmadı çünkü ayrı bir sayfa açıp oraya yazabiliriz. 
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Save(EntryViewModel data)
        {
            entry_master ed = new entry_master();
            ed.id = data.id;
            ed.waybill_no = data.waybill_no;

            if (ed.id == 0)
            {
                _context.entry_masters.Add(ed);//Veritabanındaki stok giriş detail sayfasına ekle.
            }
            else
            {
                _context.entry_masters.Update(ed);//Veritabanındaki ürünü günceller.
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Entry");
        }


       // SİLME İŞLEMİ EKLENECEK

    }
}
