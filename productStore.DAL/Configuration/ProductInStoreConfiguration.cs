using productStore.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productStore.DAL.Configuration
{
    public class ProductInStoreConfiguration
    {
        public void Configure(EntityTypeBuilder<ProductInStore> builder)
        {
            builder.ToTable("product_in_store");
            builder.HasKey(k => new { k.StoreId, k.ProductId });

            builder.Property(p => p.Quantity).HasColumnName("quantity").HasMaxLength(20).IsRequired();
            builder.Property(p => p.Price).HasColumnName("price").HasMaxLength(20).IsRequired();

            builder.HasOne(stockItem => stockItem.Product)
                .WithMany(p => p.ProductInStores)
                .HasForeignKey(ps => ps.ProductId);

            builder.HasOne(stockItem => stockItem.Store)
                .WithMany(s => s.ProductInStores)
                .HasForeignKey(ps => ps.StoreId);
        }
    }
}
