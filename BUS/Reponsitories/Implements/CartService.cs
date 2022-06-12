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
    public class CartService : ICartService
    {
        private readonly IGenericRepository<CartItem> _cartItemService;
        public CartService(IGenericRepository<CartItem> cartItemService)
        {
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
        }
        public bool AddCart(CartItem cartItem)
        {
            if (cartItem == null) return false;
            if (_cartItemService.GetAllDataQuery().FirstOrDefault(p => p.UserId == cartItem.UserId && p.ProductName == cartItem.ProductName) == null)
            {
                _cartItemService.AddDataCommand(cartItem);
                return true;
            }
            else
            {
                var cart = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.UserId == cartItem.UserId && p.ProductName == cartItem.ProductName);
                if (cart == null) return false;
                cart.Quantity += 1;
                _cartItemService.UpdateDataCommand(cart);
                return true;
            }
           
        }
        public List<CartItem> GetProductInCart()
        {
            return _cartItemService.GetAllDataQuery().ToList();
        }
        public bool UpdateCart(CartItem cartItem)
        {
            if (cartItem == null) return false;
            _cartItemService.UpdateDataCommand(cartItem);
            return true;
        }

    }
}
