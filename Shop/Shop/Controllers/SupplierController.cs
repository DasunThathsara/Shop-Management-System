using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ShopContext myDb;
        public SupplierController(ShopContext shopContext)
        {
            myDb = shopContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SupplierRegistrationForm(Supplier supplier)
        {
            Supplier suppliers = new Supplier()
            {
                FirstName = supplier.FirstName,
                LastName = supplier.LastName,
                Tel = supplier.Tel
            };

            myDb.Suppliers.Add(suppliers);
            myDb.SaveChanges();
            return RedirectToAction("Supplier");
        }

        public IActionResult SupplierRegistration() 
        {
            return View();
        }

        public IActionResult Supplier() 
        {
            List<Supplier> suppliers = (from supplier in this.myDb.Suppliers.Take(10)
                                        select supplier).ToList();
            return View(suppliers);
        }
    }
}
