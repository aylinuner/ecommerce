//using ecommerce.Models.View;

//using ecommerce.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;

//namespace ecommerce.Controllers
//{
//    public class ProductDetailController : Controller
//    {
//        private readonly _DbContext _context;

//        public ProductDetailController(_DbContext context)
//        {
//            _context = context;
//        }
//        public async Task<IActionResult> Index(int? id)
//        {
//            ProductViewModel model = new ProductViewModel();

//            if (id.HasValue && id > 0)
//            {
//                product p = await _context.product.FirstOrDefaultAsync(x => x.id == id);

//                if (p != null)
//                {
//                    model.id = p.id;
//                    model.name = p.name;
//                    model.price = (int)p.price;
//                    model.image_url = p.image_url;
//                    model.description = p.description;
//                }
//            }

//            return View(model);
//        }


//    }
//}
