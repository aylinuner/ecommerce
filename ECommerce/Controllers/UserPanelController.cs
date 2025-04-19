using ecommerce.Models;
using ecommerce.Models.Custom;
using ecommerce.Models.Db;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class UserPanelController : Controller
    {
        private readonly _DbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public UserPanelController(_DbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task<IActionResult> Membership()
        {
            var user = await _userManager.GetUserAsync(User); // AppUser türünde
            ViewBag.user = user;
            return View();
        }

        public async Task<IActionResult> Order()
        {
            try
            {
                List<Order> orders = await _context.Order.Include(x => x.Product).OrderBy(x => x.Id).ToListAsync();
                ViewBag.orders = orders;
            }
            catch (Exception x)
            {
                throw;
            }
            return View();
        }
        public async Task<IActionResult> Address()
        {
            try
            {
                List<UserAddress> user_addresses = await _context.UserAddress.Include(c => c.City).Include(d => d.District).OrderBy(x => x.Id).ToListAsync();
                ViewBag.user_addresses = user_addresses;
            }
            catch (Exception x)
            {
                throw;
            }
            return View();
        }

    }
}
