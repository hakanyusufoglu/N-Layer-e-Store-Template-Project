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
            CreateMap<Category, CategoryDto>(); //eğer sen category görürsen bunu categoryDto'ya çevir...
            CreateMap<CategoryDto,Category >();

            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto,Brand>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();


        }
    }
}
