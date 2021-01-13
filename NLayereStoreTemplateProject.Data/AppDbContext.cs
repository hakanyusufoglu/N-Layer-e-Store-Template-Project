using Microsoft.EntityFrameworkCore;
using NLayereStoreTemplateProject.Core.Entities;
using NLayereStoreTemplateProject.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Data
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        //bu işlemler sayesinde veritabanına yansıtılacak olan tablo isimleri belirlenmektedir.
        public DbSet<User> Users { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Veritabanı tabloları oluşmadan önce OnModelCreating() adlı metot çalışmaktadır.

            //Configuration klasörü altında ki config dosyaları eklenmektedir. Böylece tanımlanan kısıtlamalar tablolar için gerçekleşmektedir.

            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            

        }
    }
}
