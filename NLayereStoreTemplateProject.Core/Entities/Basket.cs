using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Core.Entities
{
   public class Basket
    {
        public int BasketId { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
