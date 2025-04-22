using ecommerce.Models;
using ecommerce.Models.Custom;
using ecommerce.Models.Db;
using ecommerce.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;


namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Admin")]

    //[Route("Admin")]
    //[ApiController]
    public class EntryController : Controller
    {
        private readonly _DbContext _context;
        public EntryController(_DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            try
            {
                List<EntryMaster> entry_masters = await _context.EntryMaster.OrderBy(x => x.Id).ToListAsync();
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
                //veritabanındaki giriş kaydı. entyr_master içindeki entry_detail include ettik onunda içindeki product'ı include(dahil) ettik.
                EntryMaster em = _context.EntryMaster.Include(x => x.EntryDetail).ThenInclude(ed => ed.).FirstOrDefault(x => x.Id == id);

                if (em != null) // Eğer kayıt bulunursa
                {
                    // ViewModel'e DB'deki ana verileri aktar
                    vm.Id = em.Id;
                    vm.WaybillNo = em.WaybillNo;
                    vm.WaybillDate = em.WaybillDate;
                    vm.WaybillTotal = em.WaybillTotal;
                    vm.SupplierId = em.SupplierId;
                    vm.ReceiverId = em.ReceiverId;


                    // entry_details'i EntryDetailViewModel listesi olarak doldur
                    vm.EntryDetails = em.EntryDetail.Select(d => new EntryDetailViewModel
                    {
                        Id = d.Id,
                        ProductId = d.ProductId,
                        Product = d.Product,
                        Quantity = d.Quantity,
                        Amount = d.Amount,
                        TotalAmount = d.TotalAmount,
                        Weight = d.Weight,
                        CreateDate = d.CreateDate,
                        UpdateDate = d.UpdateDate,
                        EntryMasterId = d.EntryMasterId


                    }).ToList();
                }
            }
            //Tedarikçi firmaları getir.
            List<Company> suppliers = await _context.Company.ToListAsync();
            ViewBag.suppliers = suppliers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();

            //Kullanıcıları Getir

            List<AppUser> users = await _context.AppUser.ToListAsync();
            ViewBag.users = users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.UserName
            }).ToList();

            //ViewBag.products = await _context.Product.Select(p => new SelectListItem
            //{
            //    Value = p.Id.ToString(),
            //    Text = p.Name
            //}).ToListAsync();

            return View(vm);
        }


        [HttpPost]

        //Save parametresi olarak tek bir parametre ekliyoruz. Port methodunda iki tane parametre gönderemeyiz.
        public async Task<IActionResult> Save(EntryViewModel data)
        {
            // entry_master nesnesini oluştur
            EntryMaster em = new EntryMaster
            {
                Id = data.Id,
                WaybillNo = data.WaybillNo,
                WaybillDate = data.WaybillDate,
                WaybillTotal = data.WaybillTotal,
                SupplierId = data.SupplierId,
                ReceiverId = data.ReceiverId,
                CreateDate = DateTime.Now,
                //  entry_details=data.entry_details
            };
            foreach (var item in data.EntryDetails)
            {
                //em (entry_master) 'ye entry_details'i ekliyoruz. ve entry_details property'lerini tek tek giriyoruz. 
                em.EntryDetail.Add(new EntryDetail
                {
                    EntryMasterId = em.Id,
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Amount = item.Amount,
                    TotalAmount = item.TotalAmount,
                    Weight = item.Weight,
                    UpdateDate = DateTime.Now,
                    CreateDate = DateTime.Now

                });
            }
            if (em.Id == 0)
            {

                _context.EntryMaster.Add(em);
            }
            else
            {
                _context.EntryMaster.Update(em);

            }


            await _context.SaveChangesAsync(); // Asenkron olarak kaydet

            return RedirectToAction("Save", "Entry", new { id = em.Id, });

        }


        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            var product = _context.EntryDetail
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    id = p.Id,
                    product_id = p.ProductId,
                    quantity = p.Quantity,
                    amount = p.Amount,
                    total_amount = p.TotalAmount,
                    weight = p.Weight
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
            EntryMaster em = _context.EntryMaster.FirstOrDefault(x => x.Id == id);

            _context.EntryMaster.Remove(em);
            _context.SaveChanges();
            return RedirectToAction("Index", "Entry");


        }


        public IActionResult List()
        {
            return View();
        }


    }
}
