//using ecommerce.Controllers;
//using ecommerce.Models;
//using ecommerce.Models.View;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

//namespace ecommerce.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class CustomerController : Controller
//    {
//        private readonly _DbContext _context;
        
//        public CustomerController(_DbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            try
//            {
//                List<customer> customers = _context.customer.ToList();
//                ViewBag.customers = customers;
//            }
//            catch 
//            {
//                throw;
//            }
//            return View();
//        }

//        [HttpGet]
//        public async Task<IActionResult> Save(int id)
//        {
//            CustomerViewModel model = new CustomerViewModel();

//            if (id > 0)
//            {
//                customer c = _context.customer.FirstOrDefault(x => x.id == id);
//                model.name = c.name;
//                model.surname = c.surname;
//                //model.phone_area = c.phone_area;
//                model.phone_number = c.phone_number;
//                model.gender = c.gender;
//                model.create_date = DateTime.Now;
//                model.birth_date = c.birth_date;
//                //model.email = c.email;
//                //model.password = c.password;
//                model.type = c.type;
//                model.save_date = c.save_date;
//            }
//            return View(model);
//        }
//        [HttpGet]
//        public IActionResult Save(CustomerViewModel data)
//        {
//            customer c = new customer();
//            c.name = data.name;
//            c.surname = data.surname;
//            //c.phone_area = data.phone_area;
//            c.phone_number = data.phone_number;
//            c.gender = data.gender;
//            c.create_date = DateTime.Now;
//            c.birth_date = data.birth_date;
//            //c.email = data.email;
//            //c.password = data.password;
//            c.type = data.type;
//            c.save_date = data.save_date;

//            if (c.id == 0)
//            {
//                _context.customer.Add(c);
//            }
//            else
//            {
//                _context.customer.Update(c);
//            }
//            _context.SaveChanges();
//            return RedirectToAction("Index", "Customer");
//        }
//        [HttpGet]
//        public IActionResult Delete(int id)
//        {
//            customer c = _context.customer.FirstOrDefault(x => x.id == id);
//            _context.customer.Remove(c);
//            _context.SaveChanges();

//            return RedirectToAction("Index", "Customer");
//        }
//        public IActionResult List()
//        {
//            return View();
//        }
//    }
//}
