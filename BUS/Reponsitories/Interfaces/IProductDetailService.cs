using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using BUS.Dtos;

namespace BUS.Reponsitories.Interfaces
{
    public interface IProductDetailService
    {
        #region product
        public List<Products> GetProducts();
        public bool AddProduct(Products products);
        public bool UpdateProduct(Products products);
        public bool DeleteProduct(Products products);
        #endregion
        #region productVariant
        public List<ProductVariants> GetProductVariants();
        public bool AddProductVariant(ProductVariants products);
        public bool UpdateProductVariant(ProductVariants products);
        public bool DeleteProductVariant(ProductVariants products);

        #endregion
        #region option
        public List<Options> GetOption();
        public bool AddOptin(Options options);
        public bool UpdateOption(Options options);
        public bool DeleteOption(Options options);
        #endregion

        #region optionValue
        public List<OptionValues> GetOptionValue();
        public bool AddGetOptionValue(OptionValues optionValues);
        public bool UpdateGetOptionValue(OptionValues optionValues);
        public bool DeleteGetOptionValue(OptionValues optionValues);
        #endregion
        #region productOption 
        public List<ProductOptions> GetProductOptions();
        public bool AddProductOption(ProductOptions productOptions);
        public bool UpdateProductOption(ProductOptions productOptions);
        public bool DeleteProductOption(ProductOptions productOptions);
        #endregion
        #region VariantValue
        public List<VariantValues> GetVariantValues();
        public bool AddVariantValue(VariantValues variantValues);
        public bool UpdateVariantValue(VariantValues variantValues);
        public bool DeleteVariantValue(VariantValues variantValues);
        #endregion
        public List<ProductDetailsDto> GetProductDetails();
        public bool AddProductDetails(ProductDetailsDto productDetails);
        public Guid CheckExistProduct(string productName);
 	public bool UpdateProductDetails(ProductDetailsDto productDetails);
        public bool RemoveProductDetails(ProductDetailsDto productDetails);
    }
}
