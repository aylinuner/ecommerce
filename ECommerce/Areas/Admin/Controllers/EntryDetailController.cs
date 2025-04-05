using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Areas.Admin.Controllers
{
    public class EntryDetailController(EcommerceDbContext context) : Controller
    {
        private readonly EcommerceDbContext _context = context;

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            entry_detail ed = _context.entry_details.FirstOrDefault(x => x.id == id);
            if (ed != null)
            {
                _context.entry_details.Remove(ed);
                _context.SaveChanges();
                return Json(new { success = true, message = "Kayıt başarıyla silindi." });
            }
            return Json(new { success = false, message = "Kayıt bulunamadı." });
        }
    }
}
