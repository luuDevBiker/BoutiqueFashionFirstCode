using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class OptionValues
    {
        public Guid valuesID { get; set; }
        public Guid optionID { get; set; }
        public int optionValues { get; set; }
        public bool isOptionValueEnabled { get; set; }
        public Options options { get; set; }
        public ICollection<VariantValues> variantValues { get; set; }

    }
}
