using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.DTOs
{
    public class ProductWithCategoryAndBrandDto:ProductDto
    {
        public CategoryDto Category { get; set; }
        public BrandDto Brand { get; set; }
    }
}
