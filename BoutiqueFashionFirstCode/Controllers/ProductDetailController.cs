using BUS.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BUS.Reponsitories.Interfaces;
using BoutiqueFashionFirstCode.ViewModel;
using BUS.ViewModel;
using Microsoft.AspNetCore.OData.Query;

namespace BoutiqueFashionFirstCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService ?? throw new ArgumentNullException(nameof(productDetailService));
        }
        [HttpGet("GetAllProductDetail")]
        public List<ProductDetailsDto> GetAllProductDetail(ODataQueryOptions<ProductDetailsDto> queryOptions)
        {
            var result= _productDetailService.GetProductDetails().AsQueryable();
            var finalResult = queryOptions.ApplyTo(result);
            var castedProductDetailColletion = finalResult.Cast<ProductDetailsDto>();
            return castedProductDetailColletion.ToList();
        }
        [HttpPost("PostProductDetail")]
        public bool PostProductDetail(ProductDetailViewModel productDetail)
        {
            var productDetailToAdd = new ProductDetailsDto();
            productDetailToAdd.ProductId = Guid.NewGuid();
            productDetailToAdd.VariantId = Guid.NewGuid();
            productDetailToAdd.ProductsName = productDetail.ProductName;
            productDetailToAdd.Price = productDetail.Price;
            productDetailToAdd.Quantity = productDetail.Quantity;
            productDetailToAdd.SkuId = productDetail.SkuId;
            productDetailToAdd.ImportPrice = productDetail.ImportPrice;
            productDetailToAdd.Option = productDetail.Option;
            productDetailToAdd.Images = productDetail.Images;
            return _productDetailService.AddProductDetails(productDetailToAdd);
        }
        [HttpPut("Updateproduct")]
        public bool UpdateProduct(UpdateProductDetail productDetail)
        {
            var productDetailToUpdate = new ProductDetailsDto();
            productDetailToUpdate.ProductId = productDetail.productId;
            productDetailToUpdate.VariantId = productDetail.VariantId;
            productDetailToUpdate.ProductsName = productDetail.productsName;
            productDetailToUpdate.Price = productDetail.price;
            productDetailToUpdate.Quantity = productDetail.quantity;
            productDetailToUpdate.SkuId = productDetail.skuId;
            productDetailToUpdate.ImportPrice = productDetail.importPrice;
            productDetailToUpdate.Option = productDetail.option;
            productDetailToUpdate.Images = productDetail.Images;
            return _productDetailService.UpdateProductDetails(productDetailToUpdate);
        }
        [HttpDelete("DeteteProduct")]
        public bool DeteteProduct(UpdateProductDetail productDetail)
        {
            var productDetails = new ProductDetailsDto();
            productDetails.ProductId = productDetail.productId;
            productDetails.VariantId = productDetail.VariantId;
            productDetails.ProductsName = productDetail.productsName;
            productDetails.Price = productDetail.price;
            productDetails.Quantity = productDetail.quantity;
            productDetails.SkuId = productDetail.skuId;
            productDetails.ImportPrice = productDetail.importPrice;
            productDetails.Option = productDetail.option;
            return _productDetailService.RemoveProductDetails(productDetails);
        }
    }
}
