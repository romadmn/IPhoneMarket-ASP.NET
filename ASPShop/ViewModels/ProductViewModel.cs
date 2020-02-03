using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.Models;

namespace ASPShop.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public string CurrentCategory { get; set; }
    }
}
