using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class ProductOptions
    {
        public Guid productID { get; set; }
        public Guid optionID { get; set; }
        public bool isProductOptionEnabled { get; set; }
        public Products products { get; set; }
        public Options options { get; set; }
    }
}
