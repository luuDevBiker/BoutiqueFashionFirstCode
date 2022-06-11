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
            }
            else
            {
                var cart = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.UserId == cartItem.UserId && p.ProductName == cartItem.ProductName);
                cart.Quantity = cartItem.Quantity;
                _cartItemService.UpdateDataCommand(cart);
            }
            return false;
        }
        public List<CartItem> GetProductInCart()
        {
            return _cartItemService.GetAllDataQuery().ToList();
        }
        public bool Order(Guid userId)
        {
            var cart = _cartItemService.GetAllDataQuery().Where(p => p.UserId == userId).ToList();
            return false;
        }
    }
}
