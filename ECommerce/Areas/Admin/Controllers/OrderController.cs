
//using ecommerce.Models;
//using ecommerce.Models.Db;
//using ecommerce.Models.View;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ecommerce.Areas.Admin.Controllers
//{
//    [Area("Admin")]

//    [Authorize(Roles = "Admin")]
//    public class OrderController : Controller
//    {
//        private readonly _DbContext _context;


//        public OrderController(_DbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]

//        public async Task<IActionResult> Index()
//        {
//            try
//            {
//                List<Order> orders = await _context.Order.Include(a => a.UserId).Include(b => b.Product).OrderBy(x => x.Id).ToListAsync();
//                ViewBag.orders = orders;
//            }
//            catch (Exception x)
//            {
//                throw;
//            }
//            return View();
//        }
//        [HttpGet]

//        public async Task<IActionResult> Save(int Id)
//        {
//            OrderViewModel model = new OrderViewModel();


//            if (Id > 0)
//            {
//                Order o = _context.Order.FirstOrDefault(x => x.Id == Id);
//                model.Id = o.Id;
//                //    model.order_id = o.order_id;
//                //    model.user_id = o.user_id;
//                //    model.total_amount = o.total_amount;
//                //    model.payment_status = o.payment_status;
//                //    model.delivery_adress = o.delivery_adress;
//                //    model.upload_date = o.upload_date;
//                //    model.payment_date = o.payment_date;
//                //    model.create_date = DateTime.Now;
//                //    model.update_date = o.update_date;
//                //}
//                return View(model);
//            }
//        }
//            [HttpPost]
//            public IActionResult Save(OrderViewModel data)
//            {
//                Order o = new Order();
//                o.Id = data.Id;
//                o.OrderId = data.OrderId;
//                o.UserId = data.UserId;
//                o.TotalAmount = data.TotalAmount;
//                o.PaymentStatus = data.PaymentStatus;
//                o.DeliveryAdress = data.DeliveryAdress;
//                o.UploadDate = data.UploadDate;
//                o.PaymentDate = data.PaymentDate;
//                o.CreateDate = DateTime.Now;
//                o.UpdateDate = data.UpdateDate;

//                if (o.Id == 0)
//                {
//                    _context.Order.Add(o);
//                }
//                else
//                {
//                    _context.Order.Update(o);
//                }

//                _context.SaveChanges();
//                return RedirectToAction("Index", "Order");
//            }

//            [HttpGet]
//            public IActionResult Delete(int Id)
//            {
//                Order o = _context.Order.FirstOrDefault(x => x.Id == Id);
//                _context.Order.Remove(o);
//                _context.SaveChanges();

//                return RedirectToAction("Index", "Order");
//            }
//        public IActionResult List()
//        {
//            return View();
//        }
//    }
//}

