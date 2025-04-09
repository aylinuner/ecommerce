using ecommerce.Models;
using ecommerce.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class UserPanelController : Controller
    {
        private readonly _DbContext _context;


        public UserPanelController(_DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Membership()
        {
            try
            {
                List<Membership> memberships = await _context.Membership.Include(u => u.Customer).OrderBy(x => x.Id).ToListAsync();
                ViewBag.memberships = memberships;
            }
            catch (Exception x)
            {
                throw;
            }
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
