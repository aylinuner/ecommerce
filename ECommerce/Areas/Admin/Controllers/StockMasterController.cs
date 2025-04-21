using ecommerce.Models;
using ecommerce.Models.Db;
using ecommerce.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                List<StockMaster> stock_masters = await _context.StockMaster.Include(c => c.Color).OrderBy(x => x.Id).ToListAsync();
                ViewBag.stock_masters = stock_masters;
            }

            catch (Exception x)
            {

                throw;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Save(string Id)
        {
            StockMasterViewModel model = new StockMasterViewModel();

            //if (Id > 0)
            //{

            //    StockMaster sm = _context.StockMaster.FirstOrDefault(x => x.Id == Id);
            //    if (sm != null) // Eğer kayıt bulunursa
            //    {
            //        model.Id = sm.Id;
            //        model.Name = sm.Name;
            //        model.Color = sm.Color;
            //    }

            //}
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(StockMasterViewModel data)
        {
            StockMaster sm = new StockMaster
            {
                Id = data.Id,
                Name = data.Name,
                Color = data.Color,
                Storage=data.Storage,
                Code=data.Code,
                ImageUrl=data.ImageUrl,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            if (sm.Id == 0)
            {
                _context.StockMaster.Add(sm);
            }
            else if (sm.Id > 0)
            {
                _context.StockMaster.Update(sm);
            }
            await _context.SaveChangesAsync(); // Asenkron olarak kaydet

            return RedirectToAction("Index", "Category", new { id = sm.Id });
        }

    }
}
