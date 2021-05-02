using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.DTOs
{
    public class BasketDto:Base
    {
        public int BasketId { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }
       
    }
}
