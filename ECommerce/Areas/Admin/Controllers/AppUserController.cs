using ecommerce.Models.Db;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Models.Custom;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        #region Dependency Enjection (DI)
        private readonly _DbContext _context;

        public AppUserController(_DbContext context)
        {
            _context = context;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<AppUserProfile> AppUserProfile = await _context.AppUserProfile.OrderBy(x => x.Id).ToListAsync();
                ViewBag.AppUserProfile = AppUserProfile;
            }

            catch (Exception x)
            {

                throw;
            }
            return View();
        }


        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var user = _context.AppUserProfile.Find(Id);
            if (user != null)
            {
                _context.AppUserProfile.Remove(user);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

    }
}