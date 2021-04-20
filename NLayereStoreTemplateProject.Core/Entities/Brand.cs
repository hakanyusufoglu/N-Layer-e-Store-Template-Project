using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NLayereStoreTemplateProject.Core.Entities
{
   public class Brand:Base
    {
        public Brand()
        {
            Products = new Collection<Product>();
        }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
