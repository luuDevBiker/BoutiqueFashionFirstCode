using BoutiqueFashionFirstCode.ViewModel;
using BUS.BusEntity;
using BUS.Reponsitories.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("GetProductInCart")]
        public List<CartItem> GetCart(Guid userId)
        {
            return _cartService.GetProductInCart(userId);
        }
        [HttpPost("AddproductInCart")]
        public bool AddCart(CartViewModel cart)
        {
            var cartitem = new CartItem();
            cartitem.CartId = Guid.NewGuid();
            cartitem.ProductId = cart.ProductId;
            cartitem.VariantId = cart.VariantId;
            cartitem.Quantity = cart.Quantity;
            cartitem.Price = cart.Price;
            cartitem.UserId = cart.UserId;
            return _cartService.AddCart(cartitem);
        }
        [HttpPut("UpdateItemInCart")]
        public bool UpdateItemInCart(CartItem cart)
        {
            return _cartService.UpdateCart(cart);
        }
        [HttpDelete("RemoveItemInCart")]
        public bool RemoveItemInCart(Guid cartid)
        {
            return _cartService.RevoteItemIncart(cartid);
        }
    }
}
