using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class VariantValues
    {
        public Guid productID { get; set; }
        public Guid variantID { get; set; }
        public Guid optionID { get; set; }
        public Guid valuesID { get; set; }
        public bool isVariantValueEnabled { get; set; }
        public ProductVariants productVariant { get; set; }
        public OptionValues optionValue { get; set; }
    }
}
