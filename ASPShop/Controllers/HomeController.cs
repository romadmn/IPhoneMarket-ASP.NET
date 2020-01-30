using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPShop.Controllers
{
    public class HomeController : Controller
    {
        MarketContext db;
        public HomeController(MarketContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }
        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return "Дякую, " + order.User + ", за покупку!";
        }
    }
}
