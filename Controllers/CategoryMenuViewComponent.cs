using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly EcommerceDbContext _context;

        public CategoryMenuViewComponent(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<category> categories = await _context.categories.ToListAsync();
            return View(categories);
        }
    }
}

