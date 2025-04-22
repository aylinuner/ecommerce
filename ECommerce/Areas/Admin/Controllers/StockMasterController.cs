using ecommerce.Models;
using ecommerce.Models.Db;
using ecommerce.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StockMasterController : Controller
    {
        #region Dependency Enjection (DI)
        private readonly _DbContext _context;

        public StockMasterController(_DbContext context)
        {
            _context = context;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<StockMaster> stock_masters = await _context.Stock.Include(c => c.Color).ToListAsync();
                ViewBag.stock_masters = stock_masters;
            }

            catch (Exception x)
            {

                throw;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Save(int Id)
        {
            StockMasterViewModel model = new StockMasterViewModel();

            if (Id > 0)
            {

                StockMaster sm = _context.Stock.FirstOrDefault(x => x.Id == Id);
                if (sm != null) // Eğer kayıt bulunursa
                {
                    model.Id = sm.Id;
                    model.Name = sm.Name;
                    model.ColorId = sm.ColorId;
                    model.Storage = sm.Storage;
                    model.Code = sm.Code;
                    model.ImageUrl = sm.ImageUrl;
                }
            }

            ViewBag.colors = await _context.Color.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToListAsync();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(StockMasterViewModel data)
        {
            StockMaster sm = new StockMaster
            {
                Id = data.Id,
                Name = data.Name,
                ColorId = data.ColorId,
                Storage = data.Storage,
                Code = data.Code,
                ImageUrl = data.ImageUrl,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            if (sm.Id == 0)
            {
                _context.Stock.Add(sm);
            }
            else if (sm.Id > 0)
            {
                _context.Stock.Update(sm);
            }
            await _context.SaveChangesAsync(); // Asenkron olarak kaydet    

            return RedirectToAction("Index", "Stock", new { Id = sm.Id });
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            StockMaster sm = _context.Stock.FirstOrDefault(x => x.Id == Id);
            _context.Stock.Remove(sm);
            _context.SaveChanges();

            return RedirectToAction("Index", "Stock");
        }


    }
}
