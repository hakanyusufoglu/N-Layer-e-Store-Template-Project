using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NLayereStoreTemplateProject.Core.Entities
{
   public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products{ get; set; }
    }
}
