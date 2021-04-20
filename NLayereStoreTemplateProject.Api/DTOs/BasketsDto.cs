using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Api.DTOs
{
    public class BasketsDto
    {
        public int BasketId { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
