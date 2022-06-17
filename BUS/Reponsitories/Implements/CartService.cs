using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using DAL.Entities;
using DAL.Reponsitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Iot.Core.Extensions;
using BUS.ViewModel;
using BUS.Exceptions;
using BUS.Profiles;

namespace BUS.Reponsitories.Implements
{
    public class CartService : ICartService
    {
        private readonly IGenericRepository<CartItem> _cartItemService;
        private readonly IProductDetailService _productDetailService;
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        public CartService(IGenericRepository<CartItem> cartItemService, IProductDetailService productDetailService, ILoginService loginService, IMapper mapper)
        {
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _productDetailService = productDetailService ?? throw new ArgumentNullException(nameof(productDetailService));
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public bool AddCart(CreatCartViewModel cart)
        {
            if (cart.ProductId.IsNullOrDefault() || Guid.Equals(cart.ProductId, Guid.Empty)) throw new ArgumentNullException("Product Id");
            if (cart.VariantId.IsNullOrDefault() || Guid.Equals(cart.VariantId, Guid.Empty)) throw new ArgumentNullException("Vatiant Id");
            if (cart.UserId.IsNullOrDefault() || Guid.Equals(cart.UserId, Guid.Empty)) throw new ArgumentNullException("User Id");
            if (cart.Quantity <0) throw new ArgumentNullException("Quantity");
            if (cart.Price <0) throw new ArgumentNullException("Price");
            if (cart.ProductName.IsNullOrDefault()) throw new ArgumentNullException("Product Name");
            var product = _productDetailService.GetProductDetails().FirstOrDefault(p => p.ProductId == cart.ProductId && p.VariantId == cart.VariantId);
            if (product == null) return false;
            if (cart.Quantity > product.Quantity) throw new ForbidException("Error Cart", "Not enough products to Order");
            var cartItem = new CartItem();
            cartItem = _mapper.Map<CartItem>(cart);
            cartItem.CartId = Guid.NewGuid();
            _cartItemService.AddDataCommand(cartItem);
            return true;
        }

        public List<CartDto> GetProductInCart(Guid userId)
        {
            if (!userId.IsNullOrDefault() || !Guid.Equals(userId, Guid.Empty))
            {
             
                var lstCartItem = _cartItemService.GetAllDataQuery().Where(p => p.UserId == userId).ToList();
                var lstCartDto = _mapper.Map<List<CartDto>>(lstCartItem);
               
                //var lstCartDtoNoImage = _mapper.Map<List<CartDto>>(lstCartItem);
                //for (int i = 0; i < lstCartDtoNoImage.Count; i++)
                //{
                //    var Image = _productDetailService.GetProductDetails().Where(p => p.VariantId == lstCartDtoNoImage[i].VariantId).Select(p => p.Images);
                //    lstCartDtoNoImage[i].ImageProduct = Image);
                //}
                return lstCartDto;
            }
            else
            {
                throw new ArgumentNullException("User null");
            }
        }

        public bool RevoteItemIncart(Guid cartId)
        {
            if (cartId.IsNullOrDefault() || Guid.Equals(cartId, Guid.Empty))
                throw new ArgumentNullException("Cart Id");
            var itemCart = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.CartId == cartId);
            if (itemCart != null)
            {
                _cartItemService.DeleteDataCommand(itemCart);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCart(UpdateCartViewModel cart)
        {
            if (cart.ProductId.IsNullOrDefault() || Guid.Equals(cart.ProductId, Guid.Empty)) throw new ArgumentNullException("Product Id");
            if (cart.VariantId.IsNullOrDefault() || Guid.Equals(cart.VariantId, Guid.Empty)) throw new ArgumentNullException("Vatiant Id");
            if (cart.UserId.IsNullOrDefault() || Guid.Equals(cart.UserId, Guid.Empty)) throw new ArgumentNullException("User Id");
            if (cart.Quantity <0) throw new ArgumentNullException("Quantity");
            if (cart.Price <0) throw new ArgumentNullException("Price");
            if (cart.ProductName.IsNullOrDefault()) throw new ArgumentNullException("Product Name");
            var itemInCartItem = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.CartId.Equals(cart.CartId));
            if (itemInCartItem.IsNullOrDefault()) throw new ForbidException("Update Cart", "Don't exist this product in your cart");
            itemInCartItem.Quantity = cart.Quantity;
            _cartItemService.UpdateDataCommand(itemInCartItem);
            return true;


        }
    }
}
