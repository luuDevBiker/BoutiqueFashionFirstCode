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
        private readonly IProductDetailService _productDetailService;
        private readonly ILoginService _loginService;
        public CartService(IGenericRepository<CartItem> cartItemService, IProductDetailService productDetailService, ILoginService loginService)
        {
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _productDetailService = productDetailService ?? throw new ArgumentNullException(nameof(productDetailService));
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }

        public bool AddCart(CartItem cartItem)
        {
            if (cartItem == null) return false;
            bool existProduct = _productDetailService.GetProductVariants().FirstOrDefault(p => p.ProductID == cartItem.ProductId && p.VariantID == cartItem.VariantId) != null;
            bool existUser = _loginService.lstUser().FirstOrDefault(p => p.UserID == cartItem.UserId) != null;
            if (existProduct && existUser)
            {
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
            else
            {
                return false;
            }

        }
        public List<CartItem> GetProductInCart(Guid userId)
        {
            var listCart = _cartItemService.GetAllDataQuery().Where(p => p.UserId == userId).ToList();
            return listCart;

        }
        public bool UpdateCart(CartItem cartItem)
        {
            if (cartItem == null) return false;
            _cartItemService.UpdateDataCommand(cartItem);
            return true;
        }
        public bool RevoteItemIncart(Guid cartid)
        {
            if (Convert.ToString(cartid) == null) return false;
            var productInCart = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.CartId == cartid);
            if (productInCart == null) return false;
            _cartItemService.DeleteDataCommand(productInCart);
            return true;

        }

    }
}
