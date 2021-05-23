using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Core.Entities
{
   public class UserApp:IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Basket> Basket { get; set; }

    }
}
