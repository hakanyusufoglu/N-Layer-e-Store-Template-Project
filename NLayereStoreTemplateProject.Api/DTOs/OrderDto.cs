using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Api.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime dateTime { get; set; }
        public int OrderCount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
