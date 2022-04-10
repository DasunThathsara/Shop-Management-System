using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShopContext myDb;
        public CustomerController(ShopContext shopContext)
        {
            myDb = shopContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerRegistrationForm(Customer customer)
        {
            Customer customers = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            myDb.Customers.Add(customers);
            myDb.SaveChanges();
            return RedirectToAction("Customer");
        }

        public IActionResult CustomerRegistration()
        {
            return View();
        }

        public IActionResult Customer()
        {
            List<Customer> customers = (from customer in this.myDb.Customers.Take(10)
                                select customer).ToList();
            return View(customers);
        }
    }
}
