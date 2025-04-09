using ecommerce.Controllers;
using ecommerce.Models;
using ecommerce.Models.Db;
using ecommerce.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly _DbContext _context;

        public CustomerController(_DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Customer> customers = _context.Customer.ToList();
                ViewBag.customers = customers;
            }
            catch
            {
                throw;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            CustomerViewModel model = new CustomerViewModel();

            if (id > 0)
            {
                Customer c = _context.Customer.FirstOrDefault(x => x.Id == id);
                model.name = c.Name;
                model.surname = c.Surname;
                //model.phone_area = c.phone_area;
                model.phone_number = c.PhoneNumber;
                model.gender = c.Gender;
                model.create_date = DateTime.Now;
                model.birth_date = c.BirthDate;
                //model.email = c.email;
                //model.password = c.password;
                model.type = c.Type;
                model.save_date = c.SaveDate;
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Save(CustomerViewModel data)
        {
            Customer c = new Customer();
            c.Name = data.name;
            c.Surname = data.surname;
            //c.phone_area = data.phone_area;
            c.PhoneNumber = data.phone_number;
            c.Gender = data.gender;
            c.CreateDate = DateTime.Now;
            c.BirthDate = data.birth_date;
            //c.email = data.email;
            //c.password = data.password;
            c.Type = data.type;
            c.SaveDate = data.save_date;

            if (c.Id == 0)
            {
                _context.Customer.Add(c);
            }
            else
            {
                _context.Customer.Update(c);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer c = _context.Customer.FirstOrDefault(x => x.Id == id);
            _context.Customer.Remove(c);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
