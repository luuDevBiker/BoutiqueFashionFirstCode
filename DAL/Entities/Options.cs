using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class Options
    {
        public Guid optionID { get; set; }
        public string optionName { get; set; }
        public bool isOptionEnabled { get; set; }
        public ICollection<ProductOptions> productOptions { get; set; }
        public ICollection<OptionValues> optionValues { get; set; }
    }
}
