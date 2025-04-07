using ecommerce.Models;
using ecommerce.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly _DbContext _context;

        public CategoryMenuViewComponent(_DbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await _context.Category.ToListAsync();
            return View(categories);
        }
    }
}

