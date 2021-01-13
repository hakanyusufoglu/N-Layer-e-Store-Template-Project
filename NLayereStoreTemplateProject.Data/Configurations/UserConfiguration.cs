using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Data.Configurations
{
    //Configuration Klasörü altında ki sınıflar veritabanına eklenecek tablolara ait kısıtlamaları (not null, unique vs) içermektedir.
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);//UserId primary key yap.
            builder.Property(x => x.UserId).UseIdentityColumn(1, 1);//identity özelliği verilmektedir.
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(75);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Adress).IsRequired().HasMaxLength(100);

        }
    }
}
