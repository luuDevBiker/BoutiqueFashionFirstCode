using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BUS.Reponsitories.Interfaces;
using BoutiqueFashionFirstCode.ViewModel;
using BUS.Dtos;
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
        public List<dynamic> GetAllProductDetail(ODataQueryOptions<ProductDetailsDto> queryOptions)
        {
            var result= _productDetailService.GetProductDetails().AsQueryable();
            var finalResult = queryOptions.ApplyTo(result);
            var castedProductDetailColletion = finalResult.Cast<ProductDetailsDto>() as IQueryable<dynamic>;
            return castedProductDetailColletion.ToList();
        }
        [HttpPost("PostProductDetail")]
        public bool PostProductDetail(ProductDetail productDetail)
        {

            var productDetails = new ProductDetailsDto();
            productDetails.ProductId = Guid.NewGuid();
            productDetails.VariantId = Guid.NewGuid();
            productDetails.ProductsName = productDetail.productsName;
            productDetails.Price = productDetail.price;
            productDetails.Quantity = productDetail.quantity;
            productDetails.SkuId = Guid.NewGuid();
            productDetails.ImportPrice = productDetail.importPrice;
            productDetails.Option = productDetail.option;
            return _productDetailService.AddProductDetails(productDetails);
        }
        [HttpPut("Updateproduct")]
        public bool UpdateProduct(UpdateProductDetail productDetail)
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
            return _productDetailService.UpdateProductDetails(productDetails);
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
