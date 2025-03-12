using ecommerce.Areas.Admin.Models.View;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class OrderController : Controller
    {
        private readonly EcommerceDbContext _context;
      

        public OrderController(EcommerceDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            try
            {
                List<order> orders = await _context.orders.OrderBy(x => x.id).ToListAsync();
                ViewBag.orders = orders;
            }
            catch (Exception x)
            {
                throw;
            }
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> Save(int id)
        {
            OrderViewModel model = new OrderViewModel();


            if (id > 0)
            {
                order o = _context.orders.FirstOrDefault(x => x.id == id);
                model.id = o.id;
                model.order_id = o.order_id;
                model.user_id = o.user_id;
                model.total_amount = o.total_amount;
                model.payment_status = o.payment_status;
                model.delivery_adress = o.delivery_adress;
                model.upload_date = o.upload_date;
                model.payment_date = o.payment_date;
                model.create_date = DateTime.Now;
                model.update_date = o.update_date;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Save(OrderViewModel data)
        {
            order o = new order();
            o.id = data.id;
            o.order_id = data.order_id;
            o.user_id = data.user_id;
            o.total_amount = data.total_amount;
            o.payment_status = data.payment_status;
            o.delivery_adress = data.delivery_adress;
            o.upload_date = data.upload_date;
            o.payment_date = data.payment_date;
            o.create_date = DateTime.Now;
            o.update_date = data.update_date;
            if (o.id == 0)
            {
                _context.orders.Add(o);
            }
            else
            {
                _context.orders.Update(o);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Order");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            order o = _context.orders.FirstOrDefault(x => x.id == id);
            _context.orders.Remove(o);
            _context.SaveChanges();

            return RedirectToAction("Index", "Order");
        }
        public IActionResult List()
        {
            return View();
        }
    }
}

