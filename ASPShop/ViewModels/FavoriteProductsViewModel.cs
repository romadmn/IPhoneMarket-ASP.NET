﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.Models;

namespace ASPShop.ViewModels
{
    public class FavoriteProductsViewModel
    {
        public IEnumerable<Product> favoriteProducts { get; set; }
    }
}
