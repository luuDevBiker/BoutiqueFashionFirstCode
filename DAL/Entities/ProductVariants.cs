using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class ProductVariants
    {
        public Guid variantID { get; set; }
        public Guid productID { get; set; }
        public Guid skuID { get; set; }

        public float importPrice { get; set; }

        public float price { get; set; }
        public int quantity { get; set; }

        public bool isProductVariantEnabled { get; set; }
        public Products product { get; set; }
        public ICollection<cartDetails> CartDetails { get; set; }
        public ICollection<VariantValues> variantValues { get; set; }

    }
}
