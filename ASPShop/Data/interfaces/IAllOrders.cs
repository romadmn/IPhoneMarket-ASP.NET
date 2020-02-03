using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.Models;

namespace ASPShop.Data.interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
