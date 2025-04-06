//using ecommerce.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace ecommerce.ViewComponents
//{
//    public class CategoryMenuViewComponent : ViewComponent
//    {
//        private readonly _DbContext _context;

//        public CategoryMenuViewComponent(_DbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            List<category> categories = await _context.category.ToListAsync();
//            return View(categories);
//        }
//    }
//}

