using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class Products
    {
        public Guid productID { get; set; }
        public string productName { get; set; }
        public bool isProductEnabled { get; set; }
        public ICollection<ProductOptions> productOptions { get; set; }
        public ICollection<ProductVariants> productVariants { get; set; }
    }
}
