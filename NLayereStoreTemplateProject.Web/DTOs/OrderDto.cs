using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.DTOs
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
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
    public enum PaymentType
    {
        Transfer = 0, //havale ile ödeme
        CreditCard = 1 //kredi kartıyla ödeme

    }
    public enum OrderStatus
    {
        Preparing = 0, //hazırlanıyor
        Prepared = 1, //hazırlandı
        Shipped = 2, // kargoya verildi
        Delivered = 3 //teslim edildi

    }
}
