using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Core.Entities
{
   public class RoleApp:IdentityRole
    {
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
