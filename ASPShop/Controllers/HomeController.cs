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
using ASPShop.ViewModels;

namespace ASPShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllProducts _allProducts;
        private readonly IProductsCategory _allCategories;
        private readonly IWebHostEnvironment _appEnvironment;
        public HomeController(IAllProducts allProducts, IProductsCategory allCategories, IWebHostEnvironment appEnvironment)
        {
            _allProducts = allProducts;
            _allCategories = allCategories;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            var favproducts = new FavoriteProductsViewModel { favoriteProducts = _allProducts.GetFavProducts};
            return View(favproducts);
        }
        [Route("Home/Products")]
        [Route("Home/Products/{category}")]
        public IActionResult Products(string category)
        {
            IEnumerable<Product> products = null;
            var currentCategory = new Category
            {
                CategoryName = "Всі товари"
            };
            if (string.IsNullOrEmpty(category))
            {
                products = _allProducts.Products.OrderBy(i=>i.Id);
            }
            else
            {
                if (string.Equals("phone", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Телефони")).OrderBy(i=>i.Id);
                    currentCategory.CategoryName = "Телефони";
                }
                else if (string.Equals("headphone", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Навушніки")).OrderBy(i => i.Id);
                    currentCategory.CategoryName = "Навушніки";
                }
                else if(string.Equals("watch", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName.Equals("Годинники")).OrderBy(i => i.Id);
                    currentCategory.CategoryName = "Годинники";
                }

            }

            var productObject = new ProductsListViewModel
            {
                AllProducts = products,
                CurrentCategory = currentCategory.CategoryName
            };
            return View(productObject);
        }
        public VirtualFileResult GetCv()
        {
            var filepath = Path.Combine("~/Files", "FerentsCV.doc");
            return File(filepath, "application/octet-stream", "FerentsCV.doc");
        }
    }
}
