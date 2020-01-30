using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data.Models;

namespace ASPShop.Data.mocks
{
    public class MockCategory : IProductsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> {
                    new Category {CategoryName = "Телефони", Desc = "Iphones"},
                    new Category {CategoryName = "Навушніки", Desc = "AirPods Та EarPods"},
                    new Category {CategoryName = "Годинники", Desc = "AppleWatches всі серії"},
                };
            }
        }
    }
}
