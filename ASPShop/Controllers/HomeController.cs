using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ASPShop.Data.Models;

namespace ASPShop.Controllers
{
    public class HomeController : Controller
    {
        MarketContext db;
        private readonly IWebHostEnvironment _appEnvironment;
        public HomeController(MarketContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            return View(db.Product.ToList());
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
            db.Order.Add(order);
            db.SaveChanges();
            return "Дякую, " + order.User + ", за замовлення. З вами скоро зв'яжуться!";
        }
        public IActionResult GetCv()
        {
            // Шлях до файлу
            string file_path = Path.Combine(_appEnvironment.WebRootPath, "Files/FerentsCV.doc");
            // Тип файла - content-type
            string file_type = "application/doc";
            string file_name = "FerentsCV.doc";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
