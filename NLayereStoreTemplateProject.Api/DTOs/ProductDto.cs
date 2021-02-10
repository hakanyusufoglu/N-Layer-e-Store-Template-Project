using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Api.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public int? UnitStock { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
