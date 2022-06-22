using BoutiqueFashionFirstCode.ViewModel;
using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using BUS.ViewModel;
using DAL.Entities;
using Iot.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;


namespace BoutiqueFashionFirstCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        }
        [HttpGet("GetProductInCart/{userId}")] // Show các sản phẩm trong giỏ hàng là Query => dùng HTTP Methor là HttpGet
        public List<CartDto> GetCart(Guid userId) // Truyền User Id để lấy được giỏ hàng của user Đó.
        {
            return _cartService.GetProductInCart(userId);// gọi đến phương thức getProductIncart ở tầng Bus.
        }
        [HttpPost("AddProductInCart")]
        public bool AddCart([FromBody] CreatCartViewModel cart)
        {
            return _cartService.AddCart(cart);
        }
        [HttpPut("UpdateProductInCart")] 
        public bool UpdateProductInCart([FromBody] UpdateCartViewModel cart) // UpdateCartViewModel Nhận các giá trị đầu vào. 
        {
            return _cartService.UpdateCart(cart); // gọi đến UpdateCart Service ở BUS.
        }
        [HttpDelete("DeteleProductInCart/{key}")]
        public bool DeteleProductInCart([FromODataUri] Guid key)
        {
            return _cartService.RemoveItemIncart(key);
        }

    }
}
