using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Api.DTOs
{
    public class BasketandProductsUserDto:Base
    {
        public int BasketId { get; set; }
        public int Quantity { get; set; }

        public ProductDto Product { get; set; }
        public UserDto User { get; set; }
    }
}
