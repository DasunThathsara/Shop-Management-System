using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ItemController : Controller
    {
        private readonly ShopContext myDb;
        public ItemController(ShopContext shopContext) 
        {
            myDb = shopContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ItemRegistrationForm(Item item) 
        {
            Item items = new Item()
            {
                ItemName = item.ItemName,
                ItemPrice = item.ItemPrice
            };

            myDb.Items.Add(items);
            myDb.SaveChanges();
            return RedirectToAction("Item");
        }

        public IActionResult ItemRegistration() 
        {
            return View();
        }
        public IActionResult Item()
        {
            List<Item> items = (from item in this.myDb.Items.Take(10)
                                        select item).ToList();
            return View(items);
        }
    }
}
