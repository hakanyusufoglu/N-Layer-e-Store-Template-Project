using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Api.DTOs
{
    public class CategoryWithProductsDto:CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
