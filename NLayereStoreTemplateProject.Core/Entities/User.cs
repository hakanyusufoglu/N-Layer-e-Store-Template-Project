using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NLayereStoreTemplateProject.Core.Entities
{
   public class User:Base
    {
        public User()
        {
            Orders = new Collection<Order>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Basket> Basket { get; set; }
    }
}
