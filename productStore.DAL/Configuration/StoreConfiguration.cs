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
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("stores");

            builder.HasKey(k => k.StoreId);

            builder.Property(p => p.StoreId).HasColumnName("store_id").IsRequired();

            builder.Property(p => p.Address).HasColumnName("store_address").IsRequired().HasMaxLength(25);
            builder.Property(p => p.Name).HasColumnName("store_name").HasMaxLength(20).IsRequired();
        }
    }
}
