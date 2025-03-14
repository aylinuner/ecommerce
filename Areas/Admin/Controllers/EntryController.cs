using ecommerce.Areas.Admin.Models.View;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        public async  Task<IActionResult> Save()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Save(EntryViewModel model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(EntryViewModel data)
        {
            //viewModel'den entity class'a veri aktarımı
          

        }

       
    }
}
