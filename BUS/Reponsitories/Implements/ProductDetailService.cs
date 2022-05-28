using BUS.BusEntity;
using BUS.Reponsitories.Interfaces;
using DAL.Entities;
using DAL.Reponsitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Implements
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IGenericRepository<Options> _optionService;
        private readonly IGenericRepository<OptionValues> _optionValueService;
        private readonly IGenericRepository<ProductOptions> _productOptionService;
        private readonly IGenericRepository<Products> _productService;
        private readonly IGenericRepository<ProductVariants> _productVariantService;
        private readonly IGenericRepository<VariantValues> _variantValueService;
        List<Options> _lstOption;
        List<ProductOptions> _lstProductOption;
        List<OptionValues> _lstOptionValue;
        List<Products> _lstProduct;
        List<ProductVariants> _lstProductVariant;
        List<VariantValues> _lstVariantValue;

        public ProductDetailService(IGenericRepository<Options> optionService, IGenericRepository<OptionValues> optionValueService, IGenericRepository<ProductOptions> productOptionService, IGenericRepository<Products> productService, IGenericRepository<ProductVariants> productVariantService, IGenericRepository<VariantValues> variantValueService)
        {
            _optionService = optionService;
            _optionValueService = optionValueService;
            _productOptionService = productOptionService;
            _productService = productService;
            _productVariantService = productVariantService;
            _variantValueService = variantValueService;
            _lstOption = new List<Options>();
            _lstProductOption = new List<ProductOptions>();
            _lstOptionValue = new List<OptionValues>();
            _lstProduct = new List<Products>();
            _lstProductVariant = new List<ProductVariants>();
            _lstVariantValue = new List<VariantValues>();
        }

        public bool AddGetOptionValue(OptionValues optionValues)
        {
            if (optionValues != null)
            {
                if (true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddOptin(Options options)
        {
            throw new NotImplementedException();
        }

        public bool AddProduct(Products products)
        {
            throw new NotImplementedException();
        }

        public bool AddProductOption(ProductOptions productOptions)
        {
            throw new NotImplementedException();
        }

        public bool AddProductVariant(ProductVariants products)
        {
            throw new NotImplementedException();
        }

        public bool AddVariantValue(VariantValues variantValues)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGetOptionValue(OptionValues optionValues)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOption(Options options)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(Products products)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductOption(ProductOptions productOptions)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductVariant(ProductVariants products)
        {
            throw new NotImplementedException();
        }

        public bool DeleteVariantValue(VariantValues variantValues)
        {
            throw new NotImplementedException();
        }

        public List<Options> GetOption()
        {
            return _lstOption = _optionService.GetAllDataQuery().Where(p => p.isOptionEnabled == true).ToList();
        }

        public List<OptionValues> GetOptionValue()
        {
            return _lstOptionValue = _optionValueService.GetAllDataQuery().Where(p => p.isOptionValueEnabled == true).ToList();
        }

        public List<ProductDetails> GetProductDetails()
        {
            var ProductDetails = new List<ProductDetails>();
            var productDetails = (
                  from a in _lstProduct
                  join b in _lstVariantValue on a.productID equals b.productID
                  join c in _lstProductVariant on a.productID equals c.productID
                  where c.productID == b.productID && c.variantID == b.variantID
                  join d in _lstOption on b.optionID equals d.optionID
                  join e in _lstOptionValue on d.optionID equals e.optionID
                  where e.optionID == b.optionID && e.valuesID == b.variantID
                  select new
                  {
                      VariantValue = b,
                      Product = a,
                      ProductVariant = c,
                      OptionValue = e,
                      Option = d
                  }


                    ).ToList();
            foreach (var x in _lstProductVariant)
            {
                var a = new ProductDetails();
                a.products = _lstProduct.FirstOrDefault(p => p.productID == x.productID);
                a.productVariants = x;
                foreach (var y in productDetails.Where(p => p.VariantValue.variantID == x.variantID).ToList())
                {
                    a.variantValues.Add(y.VariantValue);
                    a.options.Add(y.Option);
                    a.optionValues.Add(y.OptionValue);
                }
                ProductDetails.Add(a);
            }

            return ProductDetails;
        }

        public List<ProductOptions> GetProductOptions()
        {
            return _lstProductOption = _productOptionService.GetAllDataQuery().Where(p => p.isProductOptionEnabled).ToList();
        }

        public List<Products> GetProducts()
        {
            return _lstProduct = _productService.GetAllDataQuery().Where(p => p.isProductEnabled == true).ToList();
        }

        public List<ProductVariants> GetProductVariants()
        {
            return _lstProductVariant = _productVariantService.GetAllDataQuery().Where(p => p.isProductVariantEnabled == true).ToList();
        }

        public List<VariantValues> GetVariantValues()
        {
            return _lstVariantValue = _variantValueService.GetAllDataQuery().Where(p => p.isVariantValueEnabled).ToList();
        }

        public bool UpdateGetOptionValue(OptionValues optionValues)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOption(Options options)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Products products)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductOption(ProductOptions productOptions)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductVariant(ProductVariants products)
        {
            throw new NotImplementedException();
        }

        public bool UpdateVariantValue(VariantValues variantValues)
        {
            throw new NotImplementedException();
        }
    }
}
