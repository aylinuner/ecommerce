//using ecommerce.Models;
//using ecommerce.Models.View;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ecommerce.Controllers
//{
//    public class OrderController : Controller
//    {
//        private readonly _DbContext _context;

//        public OrderController(_DbContext context)
//        {
//            _context = context;
//        }
//        //Teslimat bilgileri sayfası

//        public async Task< IActionResult> Delivery()
//        {
//            try
//            {
//                List<user_address> user_addresses = await _context.user_address.Include(a=>a.city).Include(b=>b.district).OrderBy(x => x.id).ToListAsync();
//                ViewBag.user_addresses = user_addresses;
                
//                List<delivery_type> delivery_types = await _context.delivery_type.OrderBy(x => x.id).ToListAsync();
//                ViewBag.delivery_types = delivery_types;
//            }

//            catch (Exception x)
//            {

//                throw;
//            }
//            return View();
//        }
        

//        //public IActionResult Delivery()
//        //{
//        //    return View();
//        //}
//        public async Task<IActionResult> Payment()
//        {
//            try
//            {
//                List<bank> banks = await _context.bank.OrderBy(x => x.id).ToListAsync();
//                ViewBag.banks = banks;

               
//            }

//            catch (Exception x)
//            {

//                throw;
//            }
//            return View();
//        }
//    }
//}
