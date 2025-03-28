using ecommerce.Areas.Admin.Models.View;
using ecommerce.Controllers;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        #region Dependency Enjection (DI)
        private readonly EcommerceDbContext _context;

        public CategoryController(EcommerceDbContext context)
        {
            _context = context;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<category> categories = await _context.categories.OrderBy(x => x.id).ToListAsync();
                ViewBag.categories = categories;
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
            CategoryViewModel model = new CategoryViewModel();

            if (id > 0)
            {
               
                category c = _context.categories.FirstOrDefault(x => x.id == id);
                if (c != null) // Eğer kayıt bulunursa
                {
                    model.id = c.id;
                    model.name = c.name;
                    model.sort_no = c.sort_no;
                }

            }
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Save(CategoryViewModel data)
        {
            category c = new category
            {
                id = data.id,
                name = data.name,
                sort_no = data.sort_no,
                create_date = DateTime.Now
            };

            if (c.id == 0)
            {
                _context.categories.Add(c);
            }
            else if (c.id > 0)
            {
                _context.categories.Update(c);
            }
            await _context.SaveChangesAsync(); // Asenkron olarak kaydet

            return RedirectToAction("Index", "Category", new {id=c.id});
        }





        [HttpGet]
        public IActionResult Delete(int id)
        {
            category c = _context.categories.FirstOrDefault(x => x.id == id);
            _context.categories.Remove(c);
            _context.SaveChanges();

            return RedirectToAction("Index", "Category" );
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
