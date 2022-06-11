using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class Products
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public bool IsProductEnabled { get; set; }
        public ICollection<ProductOptions> ProductOptions { get; set; }
        public ICollection<ProductVariants> ProductVariants { get; set; }
    }
}
