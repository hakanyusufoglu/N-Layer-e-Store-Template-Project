using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.OrderId).UseIdentityColumn(1, 1);
            builder.Property(x => x.PaymentType).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.OrderCount).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired().HasColumnType("decimal(18,4)");
            builder.Property(x => x.UnitPrice).IsRequired().HasColumnType("decimal(18,4)"); ;
        }
    }
}
