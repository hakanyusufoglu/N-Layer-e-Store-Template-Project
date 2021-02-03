using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Api.DTOs
{
    public class ProductWithCategoryAndBrandDto:ProductDto
    {
        public CategoryDto Category { get; set; }
        public BrandDto Brand { get; set; }
    }
}
