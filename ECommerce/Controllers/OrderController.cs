using ecommerce.Models;
using ecommerce.Models.Db;
using ecommerce.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly _DbContext _context;

        public OrderController(_DbContext context)
        {
            _context = context;
        }
        //Teslimat bilgileri sayfası

        public async Task<IActionResult> Delivery()
        {
            try
            {
                List<UserAddress> user_addresses = await _context.UserAddress.Include(a => a.City).Include(b => b.District).OrderBy(x => x.Id).ToListAsync();
                ViewBag.user_addresses = user_addresses;

                List<DeliveryType> delivery_types = await _context.DeliveryType.OrderBy(x => x.Id).ToListAsync();
                ViewBag.delivery_types = delivery_types;
            }

            catch (Exception x)
            {

                throw;
            }
            return View();
        }


        //public IActionResult Delivery()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Payment()
        {
            try
            {
                List<Bank> banks = await _context.Bank.OrderBy(x => x.Id).ToListAsync();
                ViewBag.banks = banks;


            }

            catch (Exception x)
            {

                throw;
            }
            return View();
        }
    }
}
