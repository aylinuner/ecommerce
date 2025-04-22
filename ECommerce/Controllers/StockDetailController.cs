using ecommerce.Models.View;

using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using ecommerce.Models.Db;

namespace ecommerce.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly _DbContext _context;

        public ProductDetailController(_DbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ProductViewModel model = new ProductViewModel();

            if (id.HasValue && id > 0)
            {
                StockMaster p = await _context.StockMaster.FirstOrDefaultAsync(x => x.Id == id);

                if (p != null)
                {
                    model.Id = p.Id;
                    model.Name = p.Name;
                    model.Price = (int)p.Price;
                    //model.image_url = p.image_url;
                    model.Description = p.Description;
                }
            }

            return View(model);
        }


    }
}
