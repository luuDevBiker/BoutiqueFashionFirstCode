using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DAL.Entities
{
    public class ProductVariants
    {   
        public ProductVariants()
        {
            Images = new Collection<ImageProducts>();
        }
        public Guid VariantID { get; set; }
        public Guid ProductID { get; set; }
        public Guid SkuID { get; set; }

        public float ImportPrice { get; set; }

        public float Price { get; set; }
        public int Quantity { get; set; }

        public bool IsProductVariantEnabled { get; set; }
        public Products Product { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<VariantValues> VariantValues { get; set; }
        public ICollection<ImageProducts> Images { get; set; }
       

    }
}
