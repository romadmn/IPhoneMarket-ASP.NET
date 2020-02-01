﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.Models;

namespace ASPShop.Data
{
    public class MarketContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}