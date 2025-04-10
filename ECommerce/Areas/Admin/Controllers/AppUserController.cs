using ecommerce.Models.Custom;
using ecommerce.Models.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            ViewBag.Users = users;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Save(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.User = user;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(AppUser data)
        {
            if (data == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(data.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = data.UserName;
            user.Email = data.Email;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Errors = result.Errors.Select(e => e.Description).ToList();
            ViewBag.User = user;
            return View(data); // Geriye modelin bilgilerini de tekrar view'a gönder
        }

    }
}