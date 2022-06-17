using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
      
        public DateTime OrderTime { get; set; }
        public float AmountPay { get; set; }
        public float PayingCustomer { get; set; }
        public string? Description { get; set; }
        public float Payments { get; set; }
        public int StatusOrder { get; set; }
        public bool IsOrderEnabled { get; set; }
        public user User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
