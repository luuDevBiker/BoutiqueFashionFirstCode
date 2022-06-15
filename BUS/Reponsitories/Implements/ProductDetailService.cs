using BUS.Dtos;
﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        List<Options> _lstOption;
        List<ProductOptions> _lstProductOption;
        List<OptionValues> _lstOptionValue;
        List<Products> _lstProduct;
        List<ProductVariants> _lstProductVariant;
        List<VariantValues> _lstVariantValue;

        public ProductDetailService(IGenericRepository<Options> optionService, IGenericRepository<OptionValues> optionValueService, IGenericRepository<ProductOptions> productOptionService, IGenericRepository<Products> productService, IGenericRepository<ProductVariants> productVariantService, IGenericRepository<VariantValues> variantValueService, IMapper mapper)
        {
            _optionService = optionService ?? throw new ArgumentNullException(nameof(optionService));
            _optionValueService = optionValueService ?? throw new ArgumentNullException(nameof(optionValueService));
            _productOptionService = productOptionService ?? throw new ArgumentNullException(nameof(productOptionService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _productVariantService = productVariantService ?? throw new ArgumentNullException(nameof(productVariantService));
            _variantValueService = variantValueService ?? throw new ArgumentNullException(nameof(variantValueService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
                if (_optionValueService.GetAllDataQuery().Where(p => p.OptionValue.Trim().ToLower() == optionValues.OptionValue.Trim().ToLower() && p.OptionID == optionValues.OptionID).FirstOrDefault() == null)
                {
                    _optionValueService.AddDataCommand(optionValues);
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
            if (_optionService.GetAllDataQuery().Where(p => p.OptionName == options.OptionName).FirstOrDefault() == null)
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
            if (_productService.GetAllDataQuery().Where(p => p.ProductName == products.ProductName).FirstOrDefault() == null)
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
            if (_productOptionService.GetAllDataQuery().Where(p => p.ProductID == productOptions.OptionID && p.OptionID == productOptions.OptionID && p.IsProductOptionEnabled == true).FirstOrDefault() == null)
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
            if (_productVariantService.GetAllDataQuery().Where(p => p.VariantID == products.VariantID).FirstOrDefault() == null)
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
            if (_variantValueService.GetAllDataQuery().Where(p => p.VariantID == variantValues.VariantID && p.ProductID == variantValues.ProductID && p.VariantID == variantValues.VariantID && p.ValuesID == variantValues.ValuesID && p.IsVariantValueEnabled == true).FirstOrDefault() == null)
            {
                _variantValueService.AddDataCommand(variantValues);
                return true;
            }
            return false;
        }
        public bool AddProductDetails(ProductDetailsDto productDetails)
        {
            if (productDetails == null)
            {
                return false;
            }
            if (!GetProductDetails().Any(p => p.ProductsName == productDetails.ProductsName && p.Price == productDetails.Price && p.Option == productDetails.Option && p.Price == productDetails.Price && p.ImportPrice == productDetails.ImportPrice))
            {
                var product = new Products();
                product.ProductID = productDetails.ProductId;
                product.ProductName = productDetails.ProductsName;
                product.IsProductEnabled = true;
                _productService.AddDataCommand(product);
                _lstProduct.Add(product);
                var productvariant = new ProductVariants();
                productvariant.ProductID = product.ProductID;
                productvariant.VariantID = Guid.NewGuid();
                productvariant.SkuID = productDetails.SkuId;
                productvariant.ImportPrice = productDetails.ImportPrice;
                productvariant.Price = productDetails.Price;
                productvariant.Quantity = productDetails.Quantity;
                //List<ImageProducts> lstImageInProduct
                foreach (var image in productDetails.Images)
                {
                    var imageInProduct = _mapper.Map<ImageProducts>(image);
                    productvariant.Images.Add(imageInProduct);
                }
                productvariant.IsProductVariantEnabled = true;
                _productVariantService.AddDataCommand(productvariant);
                _lstProductVariant.Add(productvariant);

                var checkExistOPtion = _lstOption.Any(p => productDetails.Option.Select(entity => entity.OptionName).ToList().Contains(p.OptionName));
                foreach (var newOption in productDetails.Option)
                {
                    if (CheckExistOption(newOption.OptionName))
                    {
                        var productOption = new ProductOptions();
                        productOption.ProductID = product.ProductID;
                        var optionId = _lstOption.Where(p => p.OptionName == newOption.OptionName).Select(p => p.OptionID).FirstOrDefault();
                        productOption.OptionID = optionId;
                        productOption.IsProductOptionEnabled = true;
                        _productOptionService.AddDataCommand(productOption);
                        _lstProductOption.Add(productOption);
                        if (CheckExistOptionValue(newOption.OptionName, newOption.OptionValue))
                        {
                            var variantValue = new VariantValues();
                            variantValue.ProductID = product.ProductID;//
                            variantValue.VariantID = productvariant.VariantID;//
                            variantValue.OptionID = optionId;
                            var optionValueId = _lstOptionValue.Where(p => p.OptionValue == newOption.OptionValue).Select(p => p.ValuesID).FirstOrDefault();
                            variantValue.ValuesID = optionValueId;
                            variantValue.IsVariantValueEnabled = true;
                            _variantValueService.AddDataCommand(variantValue);
                            _lstVariantValue.Add(variantValue);
                        }
                        else
                        {
                            var optionValue = new OptionValues();
                            optionValue.OptionValue = newOption.OptionValue;
                            optionValue.OptionID = optionId;
                            optionValue.ValuesID = Guid.NewGuid();
                            optionValue.IsOptionValueEnabled = true;
                            _optionValueService.AddDataCommand(optionValue);
                            _lstOptionValue.Add(optionValue);
                            var variantValue = new VariantValues();///
                            variantValue.ProductID = product.ProductID;
                            variantValue.VariantID = productvariant.VariantID;
                            variantValue.OptionID = optionId;
                            var optionValueId = _lstOptionValue.Where(p => p.OptionValue == newOption.OptionValue).Select(p => p.ValuesID).FirstOrDefault();
                            variantValue.ValuesID = optionValueId;
                            _variantValueService.AddDataCommand(variantValue);
                            _lstVariantValue.Add(variantValue);
                        }
                    }
                    else
                    {
                        var option = new Options();
                        option.OptionID = Guid.NewGuid();
                        option.OptionName = newOption.OptionName;
                        option.IsOptionEnabled = true;
                        _lstOption.Add(option);
                        _optionService.AddDataCommand(option);
                        var optionValue = new OptionValues();
                        optionValue.OptionID = option.OptionID;
                        optionValue.ValuesID = Guid.NewGuid();
                        optionValue.OptionValue = newOption.OptionValue;
                        optionValue.IsOptionValueEnabled = true;
                        _optionValueService.AddDataCommand(optionValue);
                        _lstOptionValue.Add(optionValue);
                        var productOption = new ProductOptions();
                        productOption.ProductID = product.ProductID;
                        var optionId = option.OptionID;
                        productOption.OptionID = optionId;
                        productOption.IsProductOptionEnabled = true;
                        _productOptionService.AddDataCommand(productOption);
                        _lstProductOption.Add(productOption);
                        var variantValue = new VariantValues();
                        variantValue.ProductID = product.ProductID;//
                        variantValue.VariantID = productvariant.VariantID;//
                        variantValue.OptionID = optionId;
                        variantValue.ValuesID = optionValue.ValuesID;
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
            var optionExisted = GetOption().Any(p => p.OptionName == optionName);
            return optionExisted;
        }
        public Guid CheckExistProduct(string productName)
        {
            var productId = _lstProduct.Where(p => p.ProductName.Trim().ToLower() == productName.Trim().ToLower()).Select(p => p.ProductID).FirstOrDefault();
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
        /// <summary>
        /// Check option value exist in table option value
        /// </summary>
        /// <param name="optionName"></param>
        /// <param name="optionValue"></param>
        /// <returns>if exist return : true . else dont exist return false</returns>
        private bool CheckExistOptionValue(string optionName, string optionValue)
        {
            bool optionValueExist = true;
            var optionId = GetOption().Where(p => p.OptionName == optionName).Select(p => p.OptionID).FirstOrDefault();
            optionValueExist = GetOptionValue().Any(p => p.OptionID == optionId && p.OptionValue == optionValue);
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
            if (variantValues == null)
            {
                return false;
            }
            _variantValueService.DeleteDataCommand(variantValues);
            return true;
        }

        public List<Options> GetOption()
        {
            return _lstOption = _optionService.GetAllDataQuery().Where(p => p.IsOptionEnabled == true).ToList();
        }

        public List<OptionValues> GetOptionValue()
        {
            return _lstOptionValue = _optionValueService.GetAllDataQuery().Where(p => p.IsOptionValueEnabled == true).ToList();
        }

        public List<ProductDetailsDto> GetProductDetails()
        {
            var getAllProductDetails =
                (from a in _lstVariantValue
                 group a by new
                 {
                     a.ProductID,
                     a.VariantID
                 } into z
                 join b in _lstProduct on z.Key.ProductID equals b.ProductID
                 from c in _lstProductVariant.Where(p => p.ProductID == z.Key.ProductID && p.VariantID == z.Key.VariantID)
                 select new ProductDetailsDto
                 {
                     ProductId = b.ProductID,
                     VariantId = z.Key.VariantID,
                     ProductsName = b.ProductName,
                     SkuId = c.SkuID,
                     ImportPrice = c.ImportPrice,
                     Quantity = c.Quantity,
                     Price = c.Price,
                     Images = c.Images,
                     Option = (from d in _lstVariantValue
                               join e in _lstOption on d.OptionID equals e.OptionID
                               join f in _lstOptionValue on d.ValuesID equals f.ValuesID
                               where d.ProductID == z.Key.ProductID && d.VariantID == z.Key.VariantID
                               select new OptionDto
                               {
                                   OptionName = e.OptionName,
                                   OptionValue = f.OptionValue
                               }).ToList()
                 }).ToList();
            return getAllProductDetails;
        }
        public bool UpdateProductDetails(ProductDetailsDto productDetails)
        {
            if (productDetails == null || productDetails.ProductsName == null || productDetails.ProductId == null || productDetails.Option == null) return false;
            bool CheckStatus = false;
            Products product = _lstProduct.FirstOrDefault(p => p.ProductID == productDetails.ProductId);
            if (product == null) return false;
            product.ProductName = productDetails.ProductsName;
            ProductVariants productVariant = _lstProductVariant.FirstOrDefault(p => p.ProductID == productDetails.ProductId && p.VariantID == productDetails.VariantId);
            if (productVariant == null) return false;
            productVariant.Price = productDetails.Price;
            productVariant.Quantity = productDetails.Quantity;
            productVariant.SkuID = productDetails.SkuId;
            productVariant.ImportPrice = productDetails.ImportPrice;
            productVariant.Images = productDetails.Images;
            UpdateProduct(product); // update product
            int indexProduct = _lstProduct.FindIndex(p => p.ProductID == productDetails.ProductId);
            _lstProduct.RemoveAt(indexProduct);
            _lstProduct.Add(product);
            var imageDto = productDetails.Images.ToList();

            UpdateProductVariant(productVariant); // update product variant 
            int indexProductVariant = _lstProductVariant.FindIndex(p => p.ProductID == productDetails.ProductId);
            _lstProductVariant.RemoveAt(indexProductVariant);
            _lstProductVariant.Add(productVariant);
            var productDetailOld = GetProductDetails().FirstOrDefault(p => p.ProductId == productDetails.ProductId && p.VariantId == productDetails.VariantId);
            if (productDetailOld == null) return false;
            for (int i = 0; i < productDetails.Option.Count; i++)
            {
                for (int j = 0; j < productDetailOld.Option.Count; j++)
                {
                    bool checkOptionExist = true;
                    if (productDetails.Option[i].OptionName == productDetailOld.Option[j].OptionName) // check trùng option
                    {
                        Guid optionId = _lstOption.Where(p => p.OptionName == productDetails.Option[i].OptionName)
                        .Select(p => p.OptionID).FirstOrDefault();
                        if (productDetails.Option[i].OptionValue != productDetailOld.Option[j].OptionValue)
                        {
                            if (CheckExistOptionValue(productDetails.Option[i].OptionName, productDetails.Option[i].OptionValue))
                            {
                                // take option value ID of variant value in update
                                Guid optionValueId =
                                    _lstOptionValue
                                    .Where(p =>
                                        p.OptionValue == productDetails.Option[i].OptionValue &&
                                        p.OptionID == optionId
                                    )
                                    .Select(p => p.ValuesID)
                                    .FirstOrDefault();
                                var variantValues =
                                     _lstVariantValue
                                     .FirstOrDefault(p =>
                                         p.OptionID == optionId &&
                                         p.ProductID == productDetails.ProductId &&
                                         p.VariantID == productDetails.VariantId
                                          );
                                if (variantValues == null) return false;
                                if (variantValues.ValuesID == optionValueId && variantValues.IsVariantValueEnabled == false)
                                {
                                    variantValues.IsVariantValueEnabled = true;
                                    UpdateVariantValue(variantValues);
                                }
                                else
                                {
                                    variantValues.IsVariantValueEnabled = false;
                                    UpdateVariantValue(variantValues);
                                    variantValues.ValuesID = optionValueId;
                                    AddVariantValue(variantValues);
                                }
                                int indexUpdate =
                                    _lstVariantValue
                                    .FindIndex(p =>
                                        p.VariantID == variantValues.VariantID &&
                                        p.ProductID == productDetails.ProductId &&
                                        p.OptionID == optionId
                                        );
                                _lstVariantValue.RemoveAt(indexUpdate);
                                _lstVariantValue.Add(variantValues);
                            }
                            else
                            {
                                OptionValues optionValues = new OptionValues();
                                optionValues.ValuesID = Guid.NewGuid();
                                optionValues.OptionValue = productDetails.Option[i].OptionValue;
                                optionValues.OptionID = optionId;
                                optionValues.IsOptionValueEnabled = true;
                                AddGetOptionValue(optionValues);// add optionvalue
                                _lstOptionValue.Add(optionValues);
                                var variantValues = _lstVariantValue.FirstOrDefault(p => p.OptionID == optionId && p.ProductID == productDetails.ProductId && p.VariantID == productDetails.VariantId && p.IsVariantValueEnabled == true);
                                if (variantValues == null) return false;
                                variantValues.IsVariantValueEnabled = false;
                                UpdateVariantValue(variantValues);
                                variantValues.IsVariantValueEnabled = true;
                                variantValues.ValuesID = optionValues.ValuesID;
                                AddVariantValue(variantValues);// update variantvalue
                                int indexUpdate = _lstVariantValue.FindIndex(p => p.VariantID == variantValues.VariantID);
                                _lstVariantValue.RemoveAt(indexUpdate);
                                _lstVariantValue.Add(variantValues);
                            }
                        }
                        checkOptionExist = false;
                        break;
                    }
                    else if (checkOptionExist && j + 1 == productDetailOld.Option.Count)
                    {
                        if (CheckExistOption(productDetails.Option[i].OptionName))
                        {
                            Guid optionId = _lstOption.Where(p => p.OptionName == productDetails.Option[i].OptionName)
                            .Select(p => p.OptionID).FirstOrDefault();
                            if (CheckExistOptionValue(productDetails.Option[i].OptionName, productDetails.Option[i].OptionValue))
                            {
                                var optionValueId =
                                 _lstOptionValue
                                 .Where(p =>
                                     p.OptionValue == productDetails.Option[i].OptionValue &&
                                     p.OptionID == optionId
                                 )
                                 .Select(p => p.ValuesID)
                                 .FirstOrDefault();
                                var variantValue = new VariantValues();
                                variantValue.ProductID = productDetails.ProductId;
                                variantValue.VariantID = productDetails.VariantId;
                                variantValue.OptionID = optionId;
                                variantValue.ValuesID = optionValueId;
                                variantValue.IsVariantValueEnabled = true;
                                var checkExist = _lstVariantValue.FirstOrDefault(p => p.ProductID == variantValue.ProductID && p.VariantID == variantValue.VariantID && p.OptionID == variantValue.OptionID && p.ValuesID == variantValue.ValuesID);
                                if (checkExist == null)
                                {
                                    UpdateVariantValue(variantValue);
                                }
                                else
                                {
                                    AddVariantValue(variantValue);
                                    _lstVariantValue.Add(variantValue);
                                }
                            }
                            else
                            {
                                OptionValues optionValues = new OptionValues();
                                optionValues.ValuesID = Guid.NewGuid();
                                optionValues.OptionValue = productDetails.Option[i].OptionValue;
                                optionValues.OptionID = optionId;
                                optionValues.IsOptionValueEnabled = true;
                                AddGetOptionValue(optionValues);
                                _lstOptionValue.Add(optionValues);
                                var variantValue = new VariantValues();
                                variantValue.ProductID = productDetails.ProductId;
                                variantValue.VariantID = productDetails.VariantId;
                                variantValue.OptionID = optionId;
                                variantValue.ValuesID = optionValues.ValuesID;
                                AddVariantValue(variantValue);
                                _lstVariantValue.Add(variantValue);
                            }
                        }
                        else
                        {
                            var option = new Options();
                            option.OptionID = Guid.NewGuid();
                            option.OptionName = productDetails.Option[i].OptionName;
                            option.IsOptionEnabled = true;
                            AddOptin(option);
                            _lstOption.Add(option);
                            var optionValue = new OptionValues();
                            optionValue.ValuesID = Guid.NewGuid();
                            optionValue.OptionID = option.OptionID;
                            optionValue.OptionValue = productDetails.Option[i].OptionValue;
                            optionValue.IsOptionValueEnabled = true;
                            AddGetOptionValue(optionValue);
                            _lstOptionValue.Add(optionValue);
                            var productOption = new ProductOptions();
                            productOption.ProductID = productDetails.ProductId;
                            productOption.OptionID = option.OptionID;
                            productOption.IsProductOptionEnabled = true;
                            AddProductOption(productOption);
                            _lstProductOption.Add(productOption);
                            var variantValue = new VariantValues();
                            variantValue.ProductID = productDetails.ProductId;
                            variantValue.VariantID = productDetails.VariantId;
                            variantValue.OptionID = option.OptionID;
                            variantValue.ValuesID = optionValue.ValuesID;
                            variantValue.IsVariantValueEnabled = true;
                            AddVariantValue(variantValue);
                            _lstVariantValue.Add(variantValue);
                        }
                        break;
                    }
                }
            }
            var forProductVariant = GetProductDetails().FirstOrDefault(p => p.ProductId == productDetails.ProductId && p.VariantId == productDetails.VariantId);
            for (int i = 0; i < forProductVariant.Option.Count; i++)
            {
                bool checkExist = true;
                for (int j = 0; j < productDetails.Option.Count; j++)
                {
                    if (forProductVariant.Option[i].OptionName == productDetails.Option[j].OptionName && forProductVariant.Option[i].OptionValue == productDetails.Option[j].OptionValue)
                    {
                        checkExist = false;
                    }
                    if (checkExist && j + 1 == productDetails.Option.Count)
                    {
                        var optionId = _lstOption.Where(p => p.OptionName == forProductVariant.Option[i].OptionName).Select(p => p.OptionID).FirstOrDefault();
                        var valueId = _lstOptionValue.Where(p => p.OptionValue == forProductVariant.Option[i].OptionValue && p.OptionID == optionId).Select(p => p.ValuesID).FirstOrDefault();
                        var vv = _lstVariantValue.FirstOrDefault(p => p.ProductID == productDetails.ProductId && p.VariantID == productDetails.VariantId && p.IsVariantValueEnabled == true && p.OptionID == optionId && p.ValuesID == valueId);
                        if (vv == null) return false;
                        vv.IsVariantValueEnabled = false;
                        UpdateVariantValue(vv);
                    }
                }
            }
            CheckStatus = true;
            return CheckStatus;
        }

        public bool RemoveProductDetails(ProductDetailsDto productDetails)
        {
            var variants = _lstVariantValue.Where(p => p.ProductID == productDetails.ProductId && p.VariantID == productDetails.VariantId).ToList();
            if (variants.Count == 0) return false;
            foreach (var variant in variants)
            {
                variant.IsVariantValueEnabled = false;
                _variantValueService.UpdateDataCommand(variant);
            }
            return true;
        }
        public List<ProductOptions> GetProductOptions()
        {
            return _lstProductOption = _productOptionService.GetAllDataQuery().Where(p => p.IsProductOptionEnabled == true).ToList();
        }

        public List<Products> GetProducts()
        {
            return _lstProduct = _productService.GetAllDataQuery().Where(p => p.IsProductEnabled == true).ToList();
        }

        public List<ProductVariants> GetProductVariants()
        {
            return _lstProductVariant = _productVariantService.GetAllDataQuery().Where(p => p.IsProductVariantEnabled == true).ToList();
        }

        public List<VariantValues> GetVariantValues()
        {
            return _lstVariantValue = _variantValueService.GetAllDataQuery().Where(p => p.IsVariantValueEnabled == true).ToList();
        }

        public bool UpdateGetOptionValue(OptionValues optionValues)
        {
            if (optionValues == null)
            {
                return false;
            }
            _optionValueService.UpdateDataCommand(optionValues);
            return true;
        }

        public bool UpdateOption(Options options)
        {
            if (options == null)
            {
                return false;
            }
            _optionService.UpdateDataCommand(options);
            return true;
        }

        public bool UpdateProduct(Products products)
        {
            if (products == null)
            {
                return false;
            }
            _productService.UpdateDataCommand(products);
            return true;
        }

        public bool UpdateProductOption(ProductOptions productOptions)
        {
            if (productOptions == null)
            {
                return false;
            }
            _productOptionService.UpdateDataCommand(productOptions);
            return true;
        }

        public bool UpdateProductVariant(ProductVariants products)
        {
            if (products == null)
            {
                return false;
            }
            _productVariantService.UpdateDataCommand(products);
            return true;
        }

        public bool UpdateVariantValue(VariantValues variantValues)
        {
            if (variantValues == null)
            {
                return false;
            }
            _variantValueService.UpdateDataCommand(variantValues);
            return true;
        }
    }
}
