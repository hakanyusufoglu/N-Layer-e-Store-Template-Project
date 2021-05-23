using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Core.Entities
{
   public class Basket:Base
    {
        public int BasketId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public User User { get; set; } //will be delete
        public UserApp UserApp { get; set; } 
        public Product Product { get; set; }
    }
}
