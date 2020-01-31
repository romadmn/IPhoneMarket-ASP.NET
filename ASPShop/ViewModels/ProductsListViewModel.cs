using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.Models;

namespace ASPShop.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
        public string CurrentCategory { get; set; }
    }
}
