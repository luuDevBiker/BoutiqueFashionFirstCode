using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class Options
    {
        public Guid OptionID { get; set; }
        public string OptionName { get; set; }
        public bool IsOptionEnabled { get; set; }
        public ICollection<ProductOptions> ProductOptions { get; set; }
        public ICollection<OptionValues> OptionValues { get; set; }
    }
}
