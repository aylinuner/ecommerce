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
                entry_master db_entry = _context.entry_masters.Include(x => x.entry_details).FirstOrDefault(x => x.id == id);

                if (db_entry != null) // Eğer kayıt bulunursa
                {
                    // ViewModel'e DB'deki ana verileri aktar
                    vm.id = db_entry.id;
                    vm.waybill_no = db_entry.waybill_no;
                    vm.waybill_date = db_entry.waybill_date;
                    vm.waybill_total = db_entry.waybill_total;
                    vm.supplier_id = db_entry.supplier_id;

                    // entry_details'i EntryDetailViewModel listesi olarak doldur
                    vm.entry_details = db_entry.entry_details.Select(d => new EntryDetailViewModel
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
                Text = s.company_name
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
            entry_master ed = new entry_master();
            ed.id = data.id;
            ed.waybill_no = data.waybill_no;
            ed.waybill_date = data.waybill_date;
            ed.supplier_id = data.supplier_id;//Tedarikçi firma
            ed.receiver_id = data.receiver_id; //Teslim alan kişi

            if (ed.id == 0)//Yeni kayıt
            {
                //ed.update_date = null;
                //_context.entry_masters.Add(ed);//Veritabanındaki stok giriş detail sayfasına ekle.
                ed.create_date = DateTime.Now;
                _context.entry_masters.Add(ed);
            }
            else//Güncelleme
            {
                ed.update_date = DateTime.Now;
                _context.entry_masters.Update(ed);//Veritabanındaki ürünü günceller.
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
                        entry_detail d = await _context.entry_details.FirstOrDefaultAsync(x => x.id == detail.id);

                        if (d != null)
                        {
                            d.category_id = detail.category_id;
                            d.product_id = detail.product_id;
                            d.quantity = detail.quantity;
                            d.total = detail.total;
                            d.total_amount = detail.total_amount;
                            d.weight = detail.weight;

                            _context.entry_details.Update(d);
                        }
                    }

                }

            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Entry");
        }

        // SİLME İŞLEMİ EKLENECEK

    }
}
