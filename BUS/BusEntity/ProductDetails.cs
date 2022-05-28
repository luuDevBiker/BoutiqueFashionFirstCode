using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BUS.BusEntity
{
    public class ProductDetails
    {
        public List<ProductOptions> productOptions { get; set; }
        public Products products { get; set; }
        public ProductVariants productVariants { get; set; }
        public List<Options> options { get; set; }
        public List<OptionValues> optionValues { get; set; }
        public List<VariantValues> variantValues { get; set; }
        public ProductDetails()
        {
            productOptions = new List<ProductOptions>();
            products = new Products();
            productVariants = new ProductVariants();
            options = new List<Options>();
            variantValues = new List<VariantValues>();
            optionValues = new List<OptionValues>();
        }

        public ProductDetails(List<ProductOptions> productOptions, Products products, ProductVariants productVariants, List<Options> options, List<OptionValues> optionValues, List<VariantValues> variantValues)
        {
            this.productOptions = productOptions;
            this.products = products;
            this.productVariants = productVariants;
            this.options = options;
            this.optionValues = optionValues;
            this.variantValues = variantValues;
        }
    }
}
