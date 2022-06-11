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
            _cartItemService=cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
        }
        public bool AddCart(CartItem cartItem)
        {
            return false;
        }
    }
}
