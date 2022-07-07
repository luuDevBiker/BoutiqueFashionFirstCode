using BoutiqueFashionFirstCode.ViewModel;
using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using BUS.ViewModel;
using DAL.Entities;
using Iot.Core.Extensions;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("GetProductInCart/{userId}")]
        [Authorize]
        public List<CartDto> GetCart(Guid userId)
        {
            return _cartService.GetProductInCart(userId);
        }
        [HttpPost("AddProductInCart")]
        [Authorize]
        public Task<bool> AddCart([FromBody] CreatCartViewModel cart)
        {
            return _cartService.AddCart(cart);
        }
        [HttpPut("UpdateProductInCart")]
        [Authorize]
        public Task<bool> UpdateProductInCart([FromBody] UpdateCartViewModel cart)
        {
            return _cartService.UpdateCart(cart);
        }
        [HttpDelete("DeteleProductInCart/{key}")]
        [Authorize]
        public Task<bool> DeteleProductInCart([FromODataUri] Guid key)
        {
            return _cartService.RevoteItemIncart(key);
        }

    }
}
