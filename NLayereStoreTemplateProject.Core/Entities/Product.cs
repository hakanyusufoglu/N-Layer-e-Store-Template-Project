using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Core.Entities
{
   public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public int? UnitStock { get; set; }

        public bool IsDeleted { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brand Brand{ get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Basket> Baskets { get; set; }



    }
 
}
