using ecommerce.Areas.Admin.Models.View;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;


namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin")]
    //[ApiController]
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
            EntryViewModel vm = new EntryViewModel();

            if (id > 0)
            {
                //veritabanındaki giriş kaydı. entyr_maser içindeki entry_detail include ettik onunda içindeki product'ı include(dahil) ettik.
                entry_master em = _context.entry_masters.Include(x => x.entry_details).ThenInclude(ed=>ed.product).FirstOrDefault(x => x.id == id);

                if (em != null) // Eğer kayıt bulunursa
                {
                    // ViewModel'e DB'deki ana verileri aktar
                    vm.id = em.id;
                    vm.waybill_no = em.waybill_no;
                    vm.waybill_date = em.waybill_date;
                    vm.waybill_total = em.waybill_total;
                    vm.supplier_id = em.supplier_id;
                    vm.receiver_id = em.receiver_id;

                    // entry_details'i EntryDetailViewModel listesi olarak doldur
                    vm.entry_details = em.entry_details.Select(d => new EntryDetailViewModel
                    {
                        id = d.id,
                        category_id = d.category_id,
                        product_id = d.product_id,
                        product=d.product,
                        quantity = d.quantity,
                        total = d.total,
                        total_amount = d.total_amount,
                        weight = d.weight,
                        create_date = d.create_date,
                        update_date = d.update_date,
                        entry_master_id = d.entry_master_id

                    }).ToList();
                }
            }
            //Tedarikçi firmaları getir.
            List<company> suppliers = await _context.companies.ToListAsync();
            ViewBag.suppliers = suppliers.Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.name
            }).ToList();

            //Kullanıcıları Getir

            List<user> users = await _context.users.ToListAsync();
            ViewBag.users = users.Select(u => new SelectListItem
            {
                Value = u.id.ToString(),
                Text = u.name
            }).ToList();

            ViewBag.products = await _context.products.Select(p => new SelectListItem
            {
                Value = p.id.ToString(),
                Text = p.name
            }).ToListAsync();

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Save(EntryViewModel data)
        {
            entry_master em = new entry_master();
            em.id = data.id;
            em.waybill_no = data.waybill_no;
            em.waybill_date = data.waybill_date;
            em.waybill_total = data.waybill_total;
            em.supplier_id = data.supplier_id;//Tedarikçi firma
            em.receiver_id = data.receiver_id; //Teslim alan kişi

            foreach (var item in data.entry_details)
            {
                entry_detail ed = new entry_detail();
                ed.entry_master_id = em.id; // Yularıdaki tabloyla ilişkili olduğu için em kullandık.
                ed.id = item.id;
                ed.category_id = item.category_id;
                ed.product_id = item.product_id;
                ed.quantity = item.quantity;
                ed.total = item.total;
                ed.total_amount = item.total_amount;
                ed.weight = item.weight;
                ed.create_date = item.create_date;
                ed.update_date = item.update_date;

                em.entry_details.Add(ed);
            }

            if (em.id == 0)//Yeni kayıt
            {
                //ed.update_date = null;
                //_context.entry_masters.Add(ed);//Veritabanındaki stok giriş detail sayfasına ekle. Bunu yorum satırına aldım çünkü update demişim yanlışlık olabilir.
                em.create_date = DateTime.Now;
                _context.entry_masters.Add(em);
                await _context.SaveChangesAsync(); // Önce master kaydediliyor
            }
            else//Güncelleme
            {
                em.update_date = DateTime.Now;
                _context.entry_masters.Update(em);//Veritabanındaki ürünü günceller.
                await _context.SaveChangesAsync();
            }
            // Mevcut detayları çek
            var existingDetails = _context.entry_details.Where(d => d.entry_master_id == em.id).ToList();

            // Yeni eklenen veya güncellenen detaylar
            foreach (var item in data.entry_details)
            {
                var existingDetail = existingDetails.FirstOrDefault(d => d.id == item.id);

                if (existingDetail != null) // Güncelleme
                {
                    existingDetail.category_id = item.category_id;
                    existingDetail.product_id = item.product_id;
                    existingDetail.quantity = item.quantity;
                    existingDetail.total = item.total;
                    existingDetail.total_amount = item.total_amount;
                    existingDetail.weight = item.weight;
                    existingDetail.update_date = DateTime.Now;

                    _context.entry_details.Update(existingDetail);
                }
                else // Yeni detay ekleme
                {
                    entry_detail ed = new entry_detail
                    {
                        entry_master_id = em.id,
                        category_id = item.category_id,
                        product_id = item.product_id,
                        quantity = item.quantity,
                        total = item.total,
                        total_amount = item.total_amount,
                        weight = item.weight,
                        create_date = DateTime.Now,
                        update_date = DateTime.Now
                    };

                    _context.entry_details.Add(ed);
                }
            }

            // Silinmesi gereken detaylar (Eğer frontend'den gelen listede olmayan detay varsa sil)
            foreach (var detail in existingDetails)
            {
                if (!data.entry_details.Any(d => d.id == detail.id))
                {
                    _context.entry_details.Remove(detail);
                }
            }

            await _context.SaveChangesAsync(); // Değişiklikleri kaydet

            //EntryDetail işlemleri
            //if (data.entry_details != null && data.entry_details.Any())
            //{
            //    foreach (var detail in data.entry_details)
            //    {
            //        if (detail.id == 0) //Yeni EntryDetail
            //        {
            //            entry_detail e = new entry_detail
            //            {
            //                category_id = detail.category_id,
            //                product_id = detail.product_id,
            //                quantity = detail.quantity,
            //                total = detail.total,
            //                total_amount = detail.total_amount,
            //                weight = detail.weight,
            //                entry_master_id=detail.id //EnrtyMaster ile ilişkilendir yazmış ama sql'de ilişkilendirme(foreignkey) yaptın.
            //            };

            //            _context.entry_details.Add(e);
            //        }
            //        else //mevcut EntryDetail güncelleme
            //        {
            //            entry_detail e = await _context.entry_details.FirstOrDefaultAsync(x => x.id == detail.id);

            //            if (e != null)
            //            {
            //                e.category_id = detail.category_id;
            //                e.product_id = detail.product_id;
            //                e.quantity = detail.quantity;
            //                e.total = detail.total;
            //                e.total_amount = detail.total_amount;
            //                e.weight = detail.weight;

            //                _context.entry_details.Update(e);
            //            }
            //        }

            //  }

            //}
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Entry");
        }
        [HttpDelete]  
        public IActionResult Delete(int id)
        {
            entry_master em = _context.entry_masters.FirstOrDefault(x => x.id == id);
            if (em != null)
            {
                _context.entry_masters.Remove(em);
                _context.SaveChanges();
                return Json(new { success = true, message = "Kayıt başarıyla silindi." });
            }
            return Json(new { success = false, message = "Kayıt bulunamadı." });
        }

       
        public IActionResult List()
        {
            return View();
        }


    }
}
