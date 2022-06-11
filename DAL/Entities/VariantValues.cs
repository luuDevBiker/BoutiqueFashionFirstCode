using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class VariantValues
    {
        public Guid ProductID { get; set; }
        public Guid VariantID { get; set; }
        public Guid OptionID { get; set; }
        public Guid ValuesID { get; set; }
        public bool IsVariantValueEnabled { get; set; }
        public ProductVariants ProductVariant { get; set; }
        public OptionValues OptionValue { get; set; }
    }
}
