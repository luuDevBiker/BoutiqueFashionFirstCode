using BUS.BusEntity;
using BUS.Reponsitories.Interfaces;
using DAL.Entities;
using DAL.Reponsitories.Interfaces;

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
            _optionService = optionService ?? throw new ArgumentNullException(nameof(optionService));
            _optionValueService = optionValueService ?? throw new ArgumentNullException(nameof(optionValueService));
            _productOptionService = productOptionService ?? throw new ArgumentNullException(nameof(productOptionService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _productVariantService = productVariantService ?? throw new ArgumentNullException(nameof(productVariantService));
            _variantValueService = variantValueService ?? throw new ArgumentNullException(nameof(variantValueService));
            _lstOption = new List<Options>();
            _lstProductOption = new List<ProductOptions>();
            _lstOptionValue = new List<OptionValues>();
            _lstProduct = new List<Products>();
            _lstProductVariant = new List<ProductVariants>();
            _lstVariantValue = new List<VariantValues>();
            GetOption();
            GetOptionValue();
            GetProductOptions();
            GetProducts();
            GetProductVariants();
            GetVariantValues();
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
            if (options == null)
            {
                return false;
            }
            if (_optionService.GetAllDataQuery().Where(p => p.optionID == options.optionID).FirstOrDefault() != null)
            {
                _optionService.AddDataCommand(options);
                return true;
            }

            return false;

        }

        public bool AddProduct(Products products)
        {
            if (products == null)
            {
                return false;
            }
            if (_productService.GetAllDataQuery().Where(p => p.productID == products.productID).FirstOrDefault() != null)
            {
                _productService.AddDataCommand(products);
                return true;
            }

            return false;
        }


        public bool AddProductOption(ProductOptions productOptions)
        {
            if (productOptions == null)
            {
                return false;
            }
            if (_productOptionService.GetAllDataQuery().Where(p => p.productID == productOptions.optionID && p.optionID == productOptions.optionID).FirstOrDefault() != null)
            {
                _productOptionService.AddDataCommand(productOptions);
                return true;
            }

            return false;
        }

        public bool AddProductVariant(ProductVariants products)
        {
            if (products == null)
            {
                return false;
            }
            if (_productVariantService.GetAllDataQuery().Where(p => p.variantID == products.variantID).FirstOrDefault() != null)
            {
                _productVariantService.AddDataCommand(products);
                return true;
            }

            return false;
        }

        public bool AddVariantValue(VariantValues variantValues)
        {
            if (variantValues == null)
            {
                return false;
            }
            if (_variantValueService.GetAllDataQuery().Where(p => p.variantID == variantValues.variantID && p.productID == variantValues.productID && p.variantID == variantValues.variantID && p.valuesID == variantValues.valuesID).FirstOrDefault() != null)
            {
                _variantValueService.AddDataCommand(variantValues);
                return true;
            }

            return false;
        }
        public bool AddProductDetails(ProductDetails productDetails)
        {
            if (productDetails == null)
            {
                return false;
            }
            if (!GetProductDetails().Any(p => p.productsName == productDetails.productsName && p.price == productDetails.price && p.option == productDetails.option && p.price == productDetails.price && p.importPrice == productDetails.importPrice))
            {
                var product = new Products();
                product.productID = productDetails.productId;
                product.productName = productDetails.productsName;
                product.isProductEnabled = true;
                _productService.AddDataCommand(product);
                _lstProduct.Add(product);
                var productvariant = new ProductVariants();
                productvariant.productID = product.productID;
                productvariant.variantID = Guid.NewGuid();
                productvariant.skuID = productDetails.skuId;
                productvariant.importPrice = productDetails.importPrice;
                productvariant.price = productDetails.price;
                productvariant.quantity = productDetails.quantity;
                productvariant.isProductVariantEnabled = true;
                _productVariantService.AddDataCommand(productvariant);
                _lstProductVariant.Add(productvariant);

                var checkExistOPtion = _lstOption.Any(p => productDetails.option.Select(entity => entity.optionName).ToList().Contains(p.optionName));
                foreach (var newOption in productDetails.option)
                {
                    if (CheckExistOption(newOption.optionName))
                    {

                        var productOption = new ProductOptions();
                        productOption.productID = product.productID;
                        var optionId = _lstOption.Where(p => p.optionName == newOption.optionName).Select(p => p.optionID).FirstOrDefault();
                        productOption.optionID = optionId;
                        productOption.isProductOptionEnabled = true;
                        _productOptionService.AddDataCommand(productOption);
                        _lstProductOption.Add(productOption);
                        if (CheckExistOptionValue(newOption.optionName, newOption.optionValue))
                        {
                            var variantValue = new VariantValues();
                            variantValue.productID = product.productID;//
                            variantValue.variantID = productvariant.variantID;//
                            variantValue.optionID = optionId;
                            var optionValueId = _lstOptionValue.Where(p => p.optionValues == newOption.optionValue).Select(p => p.valuesID).FirstOrDefault();
                            variantValue.valuesID = optionValueId;
                            variantValue.isVariantValueEnabled = true;
                            _variantValueService.AddDataCommand(variantValue);
                            _lstVariantValue.Add(variantValue);

                        }
                        else
                        {
                            var optionValue = new OptionValues();
                            optionValue.optionValues = newOption.optionValue;
                            optionValue.optionID = optionId;
                            optionValue.valuesID = Guid.NewGuid();
                            optionValue.isOptionValueEnabled = true;
                            _optionValueService.AddDataCommand(optionValue);
                            _lstOptionValue.Add(optionValue);
                            var variantValue = new VariantValues();///
                            variantValue.productID = product.productID;
                            variantValue.variantID = productvariant.variantID;
                            variantValue.optionID = optionId;
                            var optionValueId = _lstOptionValue.Where(p => p.optionValues == newOption.optionValue).Select(p => p.valuesID).FirstOrDefault();
                            variantValue.valuesID = optionValueId;
                            _variantValueService.AddDataCommand(variantValue);
                            _lstVariantValue.Add(variantValue);
                        }


                    }
                    else
                    {
                        var option = new Options();
                        option.optionID = Guid.NewGuid();
                        option.optionName = newOption.optionName;
                        option.isOptionEnabled = true;
                        _lstOption.Add(option);
                        _optionService.AddDataCommand(option);
                        var optionValue = new OptionValues();
                        optionValue.optionID = option.optionID;
                        optionValue.valuesID = Guid.NewGuid();
                        optionValue.optionValues = newOption.optionValue;
                        optionValue.isOptionValueEnabled = true;
                        _optionValueService.AddDataCommand(optionValue);
                        _lstOptionValue.Add(optionValue);
                        var productOption = new ProductOptions();
                        productOption.productID = product.productID;
                        var optionId = option.optionID;
                        productOption.optionID = optionId;
                        productOption.isProductOptionEnabled = true;
                        _productOptionService.AddDataCommand(productOption);
                        _lstProductOption.Add(productOption);
                        var variantValue = new VariantValues();
                        variantValue.productID = product.productID;//
                        variantValue.variantID = productvariant.variantID;//
                        variantValue.optionID = optionId;
                        variantValue.valuesID = optionValue.valuesID;
                        _variantValueService.AddDataCommand(variantValue);
                        _lstVariantValue.Add(variantValue);

                    }
                }
                return true;

            }
            else
            {
                return false;
            }
        }
        private bool CheckExistOption(string optionName)
        {
            var optionExisted = GetOption().Any(p => p.optionName == optionName);
            return optionExisted;

        }
        public Guid CheckExistProduct(string productName)
        {
            var productId = _lstProduct.Where(p => p.productName.Trim().ToLower() == productName.Trim().ToLower()).Select(p => p.productID).FirstOrDefault();
            if (productId != null)
            {
                return productId;
            }
            else
            {
                productId = Guid.Parse("");
                return productId;
            }
        }
        private bool CheckExistOptionValue(string optionName, string optionValue)
        {
            bool optionValueExist = true;
            var optionId = GetOption().Where(p => p.optionName == optionName).Select(p => p.optionID).FirstOrDefault();
            optionValueExist = GetOptionValue().Any(p => p.optionID == optionId && p.optionValues == optionValue);
            return optionValueExist;
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
            var getAllProductDetails =
                (from a in _lstVariantValue
                 group a by new
                 {
                     a.productID,
                     a.variantID
                 } into z
                 join b in _lstProduct on z.Key.productID equals b.productID
                 from c in _lstProductVariant.Where(p => p.productID == z.Key.productID && p.variantID == z.Key.variantID)
                 select new ProductDetails
                 {
                     productId = b.productID,
                     VariantId = z.Key.variantID,
                     productsName = b.productName,
                     skuId = c.skuID,
                     importPrice = c.importPrice,
                     quantity = c.quantity,
                     price = c.price,
                     option = (from d in _lstVariantValue
                               join e in _lstOption on d.optionID equals e.optionID
                               join f in _lstOptionValue on d.valuesID equals f.valuesID
                               where d.productID == z.Key.productID && d.variantID == z.Key.variantID
                               select new Option
                               {
                                   optionName = e.optionName,
                                   optionValue = f.optionValues
                               }).ToList()
                 }).ToList();
            return getAllProductDetails;
        }

        public List<ProductOptions> GetProductOptions()
        {
            return _lstProductOption = _productOptionService.GetAllDataQuery().Where(p => p.isProductOptionEnabled == true).ToList();
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
            return _lstVariantValue = _variantValueService.GetAllDataQuery().Where(p => p.isVariantValueEnabled == true).ToList();
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
