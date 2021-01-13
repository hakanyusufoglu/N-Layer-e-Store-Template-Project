﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NLayereStoreTemplateProject.Core.Entities
{
   public class Order
    {
        public int OrderId { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus Status{ get; set; }
        public DateTime dateTime { get; set; }
        public int TotalOrder { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }



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
        Shipped =2, // kargoya verildi
        Delivered = 3 //teslim edildi

    }
}