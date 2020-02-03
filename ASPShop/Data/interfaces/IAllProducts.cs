using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.Models;

namespace ASPShop.Data.interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; } 
        IEnumerable<Product> GetFavProducts { get; }
        Product GetObjectProduct(int productId);
    }
}
