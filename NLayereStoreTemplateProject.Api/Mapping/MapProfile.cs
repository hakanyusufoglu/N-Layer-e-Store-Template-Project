using AutoMapper;
using NLayereStoreTemplateProject.Api.DTOs;
using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Api.Mapping
{
    //Hangi sınıf hangi sınıfa dönüştüreleceğine bu sınıf yardımıyla karar verilmektedir.
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap(); //eğer sen category görürsen bunu categoryDto'ya çevir...
            //CreateMap<CategoryDto,Category >();

            CreateMap<Brand, BrandDto>().ReverseMap();
           // CreateMap<BrandDto,Brand>();

            CreateMap<Order, OrderDto>().ReverseMap();
        //    CreateMap<OrderDto, Order>();

            CreateMap<Order, OrderWithProductsAndUserDto>().ReverseMap();
           // CreateMap<OrderWithProductsAndUserDto, Order>();

            CreateMap<User, UserDto>().ReverseMap();
            // CreateMap<UserDto, User>();

            CreateMap<Product, ProductDto>().ReverseMap();
         //   CreateMap<ProductDto, Product>();

            CreateMap<Basket, BasketsDto>().ReverseMap();
           // CreateMap<BasketsDto, Basket>();

            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();
            //CreateMap<ProductWithCategoryDto, Product>();

            CreateMap<Product, ProductWithCategoryAndBrandDto>().ReverseMap();
           // CreateMap<ProductWithCategoryAndBrandDto,Product>();

            CreateMap<Category, CategoryWithProductsDto>().ReverseMap();
          //  CreateMap<CategoryWithProductsDto, Category>();

            CreateMap<Basket, BasketandProductsUserDto>().ReverseMap();
           // CreateMap<BasketandProductsUserDto, Basket>();

       
        }
    }
}
