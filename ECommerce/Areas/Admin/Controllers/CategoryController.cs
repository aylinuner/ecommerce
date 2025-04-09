using ecommerce.Controllers;
using ecommerce.Models;
using ecommerce.Models.Db;
using ecommerce.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        #region Dependency Enjection (DI)
        private readonly _DbContext _context;

        public CategoryController(_DbContext context)
        {
            _context = context;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Category> categories = await _context.Category.OrderBy(x => x.Id).ToListAsync();
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

                Category c = _context.Category.FirstOrDefault(x => x.Id == id);
                if (c != null) // Eğer kayıt bulunursa
                {
                    model.id = c.Id;
                    model.name = c.Name;
                    model.sort_no = c.SortNo;
                }

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryViewModel data)
        {
            Category c = new Category
            {
                Id = data.id,
                Name = data.name,
               SortNo= data.sort_no,
                CreateDate = DateTime.Now
            };

            if (c.Id == 0)
            {
                _context.Category.Add(c);
            }
            else if (c.Id > 0)
            {
                _context.Category.Update(c);
            }
            await _context.SaveChangesAsync(); // Asenkron olarak kaydet

            return RedirectToAction("Index", "Category", new { id = c.Id });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category c = _context.Category.FirstOrDefault(x => x.Id == id);
            _context.Category.Remove(c);
            _context.SaveChanges();

            return RedirectToAction("Index", "Category");
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
