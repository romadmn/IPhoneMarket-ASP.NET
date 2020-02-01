using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPShop.Data.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly MarketContext _marketContext;

        public ProductRepository(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public IEnumerable<Product> Products => _marketContext.Product.Include(p => p.Category);
        public IEnumerable<Product> getFavProducts => _marketContext.Product.Where(p => p.IsFavourite);

        public Product GetObjectProduct(int productId) =>
            _marketContext.Product.FirstOrDefault(p => p.Id == productId);

    }
}
