using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data.Models;
using ASPShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            _allOrders = allOrders;
            _shopCart = shopCart;
        }

        public IActionResult Buy()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            int ShopCartItemsPriceSum = 0;
            int ShopCartItemsCount = 0;
            foreach (var el in _shopCart.ListShopItems)
            {
                ShopCartItemsPriceSum += el.Product.Price;
                ShopCartItemsCount++;
            }
            ViewBag.PriceSum = ShopCartItemsPriceSum;
            ViewBag.ShopCount = ShopCartItemsCount;
            ViewBag.ShopList = _shopCart.ListShopItems;
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();
            if (_shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас немає товарів в корзині!");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Success");
            }
            return View(order);
        }

        public IActionResult Success()
        {
            ViewBag.Message = "Замовлення успішно оброблено!";
            return View();
        }
    }
}
