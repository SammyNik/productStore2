using Microsoft.EntityFrameworkCore;
using productStore.DAL.Configuration;
using productStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productStore.DAL
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Store>? Stores { get; set; }
        public DbSet<ProductInStore>? ProductInStores { get; set; }

        public StoreDbContext()
        {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new StoreConfiguration().Configure(modelBuilder.Entity<Store>());
            new ProductInStoreConfiguration().Configure(modelBuilder.Entity<ProductInStore>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
