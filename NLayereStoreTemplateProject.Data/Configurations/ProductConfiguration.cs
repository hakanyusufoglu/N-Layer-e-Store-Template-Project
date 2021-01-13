using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductId).UseIdentityColumn(1,1);
            builder.Property(x => x.ImageFile).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(65);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,4)"); ;
        }
    }
}
