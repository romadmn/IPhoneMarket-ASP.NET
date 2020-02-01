using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data.Models;
using ASPShop.Data.Repository;
using ASPShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllProducts _productRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllProducts productRepository, ShopCart shopCart)
        {
            _productRepository = productRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel {_shopCart = _shopCart};
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _productRepository.Products.FirstOrDefault(i=> i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
