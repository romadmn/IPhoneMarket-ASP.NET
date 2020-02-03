using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASPShop.Data.Models
{
    public class ShopCart
    {
        private readonly MarketContext _marketContext;

        public ShopCart(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<MarketContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Product product)
        {
            _marketContext.ShopCartItem.Add(new ShopCartItem
                {ShopCartId = ShopCartId, Product = product, Price = product.Price});
            _marketContext.SaveChanges();
        }
        public void RemoveFromCart(int Id)
        {
            var item = _marketContext.ShopCartItem.FirstOrDefault(i=>i.Id == Id);
            _marketContext.ShopCartItem.Remove(item);
            _marketContext.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return _marketContext.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Product).ToList();
        }
    }
}
