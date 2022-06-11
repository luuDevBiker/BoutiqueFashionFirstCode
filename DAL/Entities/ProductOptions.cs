using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class ProductOptions
    {
        public Guid ProductID { get; set; }
        public Guid OptionID { get; set; }
        public bool IsProductOptionEnabled { get; set; }
        public Products Products { get; set; }
        public Options Options { get; set; }
    }
}
