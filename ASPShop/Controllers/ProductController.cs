using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data.Models;
using ASPShop.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ASPShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAllProducts _allProducts;
        public ProductController(IAllProducts allProducts)
        {
            _allProducts = allProducts;
        }
        public IActionResult Item(int id)
        {
            Product product = null;

            product = _allProducts.GetObjectProduct(id); 

            var productObject = new ProductViewModel { Product = product };
            return View(productObject);
        }
    }
}
