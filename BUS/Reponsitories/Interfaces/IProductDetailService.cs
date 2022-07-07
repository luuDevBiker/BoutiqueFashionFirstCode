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
        public  Task<bool> AddProduct(Products products);
        public bool UpdateProduct(Products products);
        public Task<bool> DeleteProduct(Products products);
        #endregion
        #region productVariant
        public List<ProductVariants> GetProductVariants();
        public Task<bool> AddProductVariant(ProductVariants products);
        public bool UpdateProductVariant(ProductVariants products);
        public Task<bool> DeleteProductVariant(ProductVariants products);

        #endregion
        #region option
        public List<Options> GetOption();
        public Task<bool> AddOptin(Options options);
        public bool UpdateOption(Options options);
        public Task<bool> DeleteOption(Options options);
        #endregion

        #region optionValue
        public List<OptionValues> GetOptionValue();
        public Task<bool> AddGetOptionValue(OptionValues optionValues);
        public bool UpdateGetOptionValue(OptionValues optionValues);
        public Task<bool> DeleteGetOptionValue(OptionValues optionValues);
        #endregion
        #region productOption 
        public List<ProductOptions> GetProductOptions();
        public Task<bool> AddProductOption(ProductOptions productOptions);
        public bool UpdateProductOption(ProductOptions productOptions);
        public Task<bool> DeleteProductOption(ProductOptions productOptions);
        #endregion
        #region VariantValue
        public List<VariantValues> GetVariantValues();
        public Task<bool> AddVariantValue(VariantValues variantValues);
        public bool UpdateVariantValue(VariantValues variantValues);
        public Task<bool> DeleteVariantValue(VariantValues variantValues);
        #endregion
        public List<ProductDetailsDto> GetProductDetails();
        public Task<bool> AddProductDetails(ProductDetailsDto productDetails);
        public Guid CheckExistProduct(string productName);
        public Task<bool> UpdateProductDetails(ProductDetailsDto productDetails);
        public Task<bool> RemoveProductDetails(ProductDetailsDto productDetails);
    }
}
