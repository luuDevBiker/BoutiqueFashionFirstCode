using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class cartDetails
    {
        public Guid orderID { get; set; }
        public Guid variantID { get; set; }
        public int quantity { get; set; }
        public float unitPrice { get; set; }
        public bool isOrderDetailEnabled { get; set; }
        public cart carts { get; set; }
        public ProductVariants productVariants { get; set; }
    }
}
