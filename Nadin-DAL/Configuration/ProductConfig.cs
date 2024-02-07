using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nadin_Domain.Models.Pruducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_DAL.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.productId);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(13).IsRequired();
            builder.HasIndex(p => new { p.Email, p.Date }).IsUnique();
            //builder.HasOne(p => p.UserProfiles)
            //    .WithMany(u => u.Products)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();
        }
    }
    }

