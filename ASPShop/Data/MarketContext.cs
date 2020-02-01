using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.Models;

namespace ASPShop.Data
{
    public class MarketContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }

        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
