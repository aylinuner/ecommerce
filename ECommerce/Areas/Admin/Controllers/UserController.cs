using ecommerce.Models.Custom;
using ecommerce.Models.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            ViewBag.Users = users;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Save(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();

            var viewModel = new AppUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                Email = user.Email,
                CreatedDate = user.CreatedDate,
                Roles = allRoles.Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                }).ToList(),
                SelectedRole = userRoles.FirstOrDefault() // varsa ilk rolü gösteriyoruz
            };

            ViewBag.Roles = allRoles.Select(role => new SelectListItem
            {
                Value = role.Name,
                Text = role.Name
            }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(AppUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) return NotFound();

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
            user.TwoFactorEnabled = model.TwoFactorEnabled;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ViewBag.Errors = result.Errors.Select(e => e.Description).ToList();
                ViewBag.Roles = _roleManager.Roles.Select(role => new SelectListItem
                {
                    Value = role.Name,
                    Text = role.Name
                }).ToList();
                return View(model);
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!string.IsNullOrEmpty(model.SelectedRole) && !currentRoles.Contains(model.SelectedRole))
            {
                // eski rolleri kaldır, yeni rolü ekle
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, model.SelectedRole);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]//class değil de değişken parametresi gönderdiğimiz için HttpGet olarak yazıypruz.

        public async Task<IActionResult> DeleteUserRole(string userId, string roleId)
        {
            AppUser existUser = await _userManager.FindByIdAsync(userId);

            if (existUser == null)
                return NotFound("Kullanıcı bulunamadı");

            IdentityRole role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return NotFound("Rol bulunamadı");

            var result = await _userManager.RemoveFromRoleAsync(existUser, role.Name);

            if (result.Succeeded)
            {
                // İstersen başarı mesajı verebilirsin
                return Ok("Rol başarıyla silindi");
            }
            else
            {
                // Hataları loglayabilirsin
                return BadRequest("Rol silinemedi");
            }
        }

    }
}

