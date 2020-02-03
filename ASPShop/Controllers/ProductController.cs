using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data;
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
        private readonly IProductsCategory _productCategories;
        public ProductController(IAllProducts allProducts, IProductsCategory productCategory)
        {
            _allProducts = allProducts;
            _productCategories = productCategory;
        }
        public IActionResult Item(int id)
        {
            Product product = null;
            Category category = null;
            product = _allProducts.GetObjectProduct(id);
            category = _productCategories.AllCategories.FirstOrDefault(i=> i.Id == product.CategoryId);
            var productObject = new ProductViewModel { Product = product , CurrentCategory = category.CategoryName};
            return View(productObject);
        }
    }
}
