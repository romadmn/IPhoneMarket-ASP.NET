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
            var obj = new ShopCartViewModel {ShopCart = _shopCart};
            int ShopCartItemsPriceSum = 0;
            foreach (var el in _shopCart.ListShopItems)
            {
                ShopCartItemsPriceSum += el.Product.Price;
            }

            ViewBag.PriceSum = ShopCartItemsPriceSum;
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id, int Count = 1)
        {
            var item = _productRepository.Products.FirstOrDefault(i=> i.Id == id);
            if (item != null)
            {
                for (int i = 1; i <= Count; i++)
                {
                    _shopCart.AddToCart(item);
                }
            }

            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart(int Id)
        {
            _shopCart.RemoveFromCart(Id);

            return RedirectToAction("Index");
        }
    }
}
