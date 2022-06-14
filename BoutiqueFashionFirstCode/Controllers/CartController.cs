﻿using BoutiqueFashionFirstCode.ViewModel;
using BUS.BusEntity;
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
        [HttpGet("GetProductInCart")]
        public IQueryable<CartDto> GetCart([FromHeader]Guid userId)
        {
            return _cartService.GetProductInCart(userId);
        }
        [HttpPost("AddProductInCart")]
        public bool AddCart([FromBody] CreatCartViewModel cart)
        {
            return _cartService.AddCart(cart);
        }
        [HttpPut("UpdateProductInCart")]
        public bool UpdateProductInCart(UpdateCartViewModel cart)
        {
            return _cartService.UpdateCart(cart);
        }
        [HttpDelete("DeteleProductInCart/{key}")]
        public bool DeteleProductInCart([FromODataUri] Guid key)
        {
            return _cartService.RevoteItemIncart(key);
        }

    }
}
