using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.DTOs
{
    public class OrderWithProductsAndUserDto:OrderDto
    {
        public ProductDto Product { get; set; }
        public UserDto User { get; set; }
    }
}
