using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data.Models;

namespace ASPShop.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly MarketContext _context;
        private readonly ShopCart _shopCart;

        public OrderRepository(MarketContext context, ShopCart shopCart)
        {
            _context = context;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _context.Order.Add(order);
            _context.SaveChanges();
            var item = _shopCart.ListShopItems;
            foreach (var el in item)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = el.Product.Id,
                    OrderId = order.Id,
                    Price = el.Product.Price
                };
                _context.OrderDetail.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}
