using BUS.BusEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BUS.Reponsitories.Interfaces;
using BoutiqueFashionFirstCode.ViewModel;

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
        public List<ProductDetails> GetAllProductDetail()
        {
            return _productDetailService.GetProductDetails();
        }
        [HttpPost("PostProductDetail")]
        public bool PostProductDetail(ProductDetail productDetail)
        {
           
            var productDetails = new ProductDetails();
            productDetails.productId = Guid.NewGuid();
            productDetails.VariantId = Guid.NewGuid();
            productDetails.productsName = productDetail.productsName;
            productDetails.price = productDetail.price;
            productDetails.quantity = productDetail.quantity;
            productDetails.skuId = Guid.NewGuid();
            productDetails.importPrice =productDetail.importPrice;
            productDetails.option=productDetail.option;
            return _productDetailService.AddProductDetails(productDetails);
        }
    }
}
