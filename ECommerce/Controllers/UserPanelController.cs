using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class UserPanelController : Controller
    {
        private readonly EcommerceDbContext _context;


        public UserPanelController(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Membership()
        {
            try
            {
                List<membership> memberships = await _context.memberships.Include(u => u.user).OrderBy(x => x.id).ToListAsync();
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
                List<order> orders = await _context.orders.Include(x=>x.product).OrderBy(x => x.id).ToListAsync();
                ViewBag.orders = orders;
            }
            catch (Exception x)
            {
                throw;
            }
            return View();
        }
        public async Task <IActionResult> Address()
        {
            try
            {
                List<user_address> user_addresses = await _context.user_addresses.Include(c=>c.city).Include(d=>d.district).OrderBy(x => x.id).ToListAsync();
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
