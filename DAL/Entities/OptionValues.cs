using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class OptionValues
    {
        public Guid ValuesID { get; set; }
        public Guid OptionID { get; set; }
        public string OptionValue { get; set; }
        public bool IsOptionValueEnabled { get; set; }
        public Options Options { get; set; }
        public ICollection<VariantValues> VariantValues { get; set; }

    }
}
