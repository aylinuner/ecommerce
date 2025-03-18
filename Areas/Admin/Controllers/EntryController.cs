using ecommerce.Areas.Admin.Models.View;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


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
            EntryViewModel vm = new EntryViewModel();

            if (id > 0)
            {
                //veritabanındaki giriş kaydı
                entry_master em = _context.entry_masters.Include(x => x.entry_details).FirstOrDefault(x => x.id == id);

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
            });

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

            if (em.id == 0)//Yeni kayıt
            {
                //ed.update_date = null;
                //_context.entry_masters.Add(ed);//Veritabanındaki stok giriş detail sayfasına ekle. Bunu yorum satırına aldım çünkü update demişim yanlışlık olabilir.
                em.create_date = DateTime.Now;
                _context.entry_masters.Add(em);
            }
            else//Güncelleme
            {
                em.update_date = DateTime.Now;
                _context.entry_masters.Update(em);//Veritabanındaki ürünü günceller.
            }

            //EntryDetail işlemleri
            if (data.entry_details != null && data.entry_details.Any())
            {
                foreach (var detail in data.entry_details)
                {
                    if (detail.id == 0) //Yeni EntryDetail
                    {
                        entry_detail e = new entry_detail
                        {
                            category_id = detail.category_id,
                            product_id = detail.product_id,
                            quantity = detail.quantity,
                            total = detail.total,
                            total_amount = detail.total_amount,
                            weight = detail.weight,
                            //entry_master_id=ed.id //EnrtyMaster ile ilişkilendir yazmış ama sql'de ilişkilendirme(foreignkey) yaptın.
                        };

                        _context.entry_details.Add(e);
                    }
                    else //mevcut EntryDetail güncelleme
                    {
                        entry_detail e = await _context.entry_details.FirstOrDefaultAsync(x => x.id == detail.id);

                        if (e != null)
                        {
                            e.category_id = detail.category_id;
                            e.product_id = detail.product_id;
                            e.quantity = detail.quantity;
                            e.total = detail.total;
                            e.total_amount = detail.total_amount;
                            e.weight = detail.weight;

                            _context.entry_details.Update(e);
                        }
                    }

                }

            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Entry");
        }
        [HttpDelete]  // API çağrıları için DELETE desteği ekliyoruz
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
