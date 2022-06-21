using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public Guid? ProfileId { get; set; }
        public DateTime OrderTime { get; set; }
        public Int64 AmountPay { get; set; }
        public Int64 PayingCustomer { get; set; }
        public string? Description { get; set; }
        public Int64 Payments { get; set; }
        public int StatusOrder { get; set; }
        public bool IsOrderEnabled { get; set; }
        public user User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
