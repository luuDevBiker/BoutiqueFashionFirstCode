using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class OrderDetails
    {
        public Guid OrderID { get; set; }
        public Guid VariantID { get; set; }
        public int Quantity { get; set; }
        public Int64 UnitPrice { get; set; }
        public bool IsOrderDetailEnabled { get; set; }
        public Order Orderds { get; set; }
        public ProductVariants ProductVariants { get; set; }
    }
}
