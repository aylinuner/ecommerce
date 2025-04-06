//using ecommerce.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ecommerce.Areas.Admin.Controllers
//{
//    public class EntryDetailController(_DbContext context) : Controller
//    {
//        private readonly _DbContext _context = context;

//        [HttpDelete]
//        public IActionResult Delete(int id)
//        {
//            entry_detail ed = _context.entry_detail.FirstOrDefault(x => x.id == id);
//            if (ed != null)
//            {
//                _context.entry_detail.Remove(ed);
//                _context.SaveChanges();
//                return Json(new { success = true, message = "Kayıt başarıyla silindi." });
//            }
//            return Json(new { success = false, message = "Kayıt bulunamadı." });
//        }
//    }
//}
