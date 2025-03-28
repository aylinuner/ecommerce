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
                entry_master em = _context.entry_masters.Include(x => x.entry_details).ThenInclude(ed => ed.product).FirstOrDefault(x => x.id == id);

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
                        product_id = d.product_id,
                        product = d.product,
                        quantity = d.quantity,
                        amount = d.amount,
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

        //Save parametresi olarak tek bir parametre ekliyoruz. Port methodunda iki tane parametre gönderemeyiz.
        public async Task<IActionResult> Save(EntryViewModel data)
        {
            // entry_master nesnesini oluştur
            entry_master em = new entry_master
            {
                id = data.id,
                waybill_no = data.waybill_no,
                waybill_date = data.waybill_date,
                waybill_total = data.waybill_total,
                supplier_id = data.supplier_id,
                receiver_id = data.receiver_id,
                create_date = DateTime.Now,
                //  entry_details=data.entry_details
            };
            foreach (var item in data.entry_details)
            {
                //em (entry_master) 'ye entry_details'i ekliyoruz. ve entry_details property'lerini tek tek giriyoruz. 
                em.entry_details.Add(new entry_detail
                {
                    entry_master_id = em.id,
                    id = item.id,
                    product_id = item.product_id,
                    quantity = item.quantity,
                    amount = item.amount,
                    total_amount = item.total_amount,
                    weight = item.weight,
                    update_date = DateTime.Now,
                    create_date = DateTime.Now
                });
            }
            if (em.id == 0)
            {

                _context.entry_masters.Add(em);
            }
            else 
            {
                _context.entry_masters.Update(em);

            }
           

            await _context.SaveChangesAsync(); // Asenkron olarak kaydet

            return RedirectToAction("Save", "Entry", new {  id=em.id,  });   

        }


        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            var product = _context.entry_details
                .Where(p => p.id == id)
                .Select(p => new
                {
                    id = p.id,
                    product_id = p.product_id,
                    quantity = p.quantity,
                    amount = p.amount,
                    total_amount = p.total_amount,
                    weight = p.weight
                })
                .FirstOrDefault();

            if (product == null)
            {
                return NotFound();  // Eğer ürün bulunamazsa 404 döndür
            }

            return new JsonResult(product);  // JSON olarak döndür
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            entry_master em = _context.entry_masters.FirstOrDefault(x => x.id == id);

            _context.entry_masters.Remove(em);
            _context.SaveChanges();
            return RedirectToAction("Index", "Entry");


        }


        public IActionResult List()
        {
            return View();
        }


    }
}
