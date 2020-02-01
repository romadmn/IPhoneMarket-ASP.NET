using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data.Models;

namespace ASPShop.Data.Repository
{
    public class CategoryRepository : IProductsCategory
    {
        private readonly MarketContext _marketContext;

        public CategoryRepository(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public IEnumerable<Category> AllCategories => _marketContext.Category;
    }
}
