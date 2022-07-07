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

        public async Task<bool> AddCart(CreatCartViewModel cart)
        {
           
            if (cart.VariantId.IsNullOrDefault() || Guid.Equals(cart.VariantId, Guid.Empty)) return false;
            if (cart.UserId.IsNullOrDefault() || Guid.Equals(cart.UserId, Guid.Empty)) return false;
            if (cart.Quantity <=0) return false;
          
            var product = _productDetailService.GetProductDetails().FirstOrDefault(p =>  p.VariantId == cart.VariantId);
            if (product == null) return false;
            if (cart.Quantity > product.Quantity) return false;
            var cartExist = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.VariantId == cart.VariantId);
            if (cartExist == null)
            {
                var cartItem = new CartItem();
                cartItem = _mapper.Map<CartItem>(cart);
                cartItem.ProductId = product.ProductId;
                cartItem.ProductName = product.ProductsName;
                cartItem.Quantity = cart.Quantity;
                cartItem.Images = product.Images;
                cartItem.Price = product.Price;
                cartItem.CartId = Guid.NewGuid();
                await _cartItemService.AddAsync(cartItem);
                return true;
            }
            else
            {

                var cartDto = _mapper.Map<CartItem>(cartExist);
                cartDto.Quantity += cart.Quantity;
                if (cartDto.Quantity > product.Quantity) return false;
                await _cartItemService.UpdateAsync(cartDto);
                return true;
            }
           
        }

        public  List<CartDto> GetProductInCart(Guid userId)
        {
            if (!userId.IsNullOrDefault() || !Guid.Equals(userId, Guid.Empty))
            {
             
                var lstCartItem =  _cartItemService.GetAllDataQuery().Where(p => p.UserId == userId).ToList();
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
                return null;
            }
        }

        public async Task<bool> RevoteItemIncart(Guid cartId)
        {
            if (cartId.IsNullOrDefault() || Guid.Equals(cartId, Guid.Empty))
                return false;
            var itemCart = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.CartId == cartId);
            if (itemCart != null)
            {
              await  _cartItemService.RemoveAsync(itemCart);
                return true;
            }
            else
            {
                return false;
            }
        }

        public  async Task<bool> UpdateCart(UpdateCartViewModel cart)
        {
          
            if (cart.VariantId.IsNullOrDefault() || Guid.Equals(cart.VariantId, Guid.Empty)) return false;
            if (cart.UserId.IsNullOrDefault() || Guid.Equals(cart.UserId, Guid.Empty)) return false;
            if (cart.Quantity <0) return false;


            var itemInCartItem = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.CartId.Equals(cart.CartId));
            if (itemInCartItem.IsNullOrDefault()) return false;
            itemInCartItem.Quantity = cart.Quantity;
            await _cartItemService.UpdateAsync(itemInCartItem);
            return true;


        }
    }
}
