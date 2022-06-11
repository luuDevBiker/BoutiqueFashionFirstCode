using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
      
        public DateTime OrderTime { get; set; }
        public float AmountPlay { get; set; }
        public float PayingCustomer { get; set; }
        public float Refunds { get; set; }
        public float Payments { get; set; }
        public bool StatusDelete { get; set; }
        public bool IsOrderEnabled { get; set; }
        public user User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
