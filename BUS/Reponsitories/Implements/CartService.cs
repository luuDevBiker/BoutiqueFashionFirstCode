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

        public bool AddCart(CreatCartViewModel cart) // truyền vào 1 đôi tượng có chứa VariantId, số Lượng muốn mua của sản Phẩm, Id Người dùng.
        {
           
            if (cart.VariantId.IsNullOrDefault() || Guid.Equals(cart.VariantId, Guid.Empty)) return false;
            if (cart.UserId.IsNullOrDefault() || Guid.Equals(cart.UserId, Guid.Empty)) return false;
            if (cart.Quantity <=0) return false;
          // 34->36: check null các thuộc tính truyền vào.


            var product = _productDetailService.GetProductDetails().FirstOrDefault(p =>  p.VariantId == cart.VariantId);//tìm sản phẩm trong Db.
            if (product == null) return false;// nếu không só sản phẩm, hoặc Số LƯợng trong kho không đủ thì không thêm nữa
            if (cart.Quantity > product.Quantity) return false;
            var cartExist = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.VariantId == cart.VariantId); 
            // kiểm tra mặt hàng vừa thêm vào có trùng với mặt hàng đã thêm vào giỏ hàng trước đó

            if (cartExist == null)// nếu không tồn tại thì Thêm mới Sản Phẩm vào giỏ hàng
            {
                var cartItem = new CartItem();
                cartItem = _mapper.Map<CartItem>(cart);
                cartItem.ProductId = product.ProductId;
                cartItem.ProductName = product.ProductsName;
                cartItem.Quantity = cart.Quantity;   
                cartItem.Images = product.Images;
                cartItem.Price = product.Price;
                cartItem.CartId = Guid.NewGuid();
                _cartItemService.AddDataCommand(cartItem);
               return true ;
            }
            else// nếu đã tồn tại thì số lượng của sản phẩm đó sẽ được update.
            {

                var cartDto = _mapper.Map<CartItem>(cartExist);
                cartDto.Quantity = cart.Quantity;
                if (cartDto.Quantity > product.Quantity ) return false;
                _cartItemService.UpdateDataCommand(cartDto);
                return true;
            }
           
        }

        public List<CartDto> GetProductInCart(Guid userId)
        {
            if (!userId.IsNullOrDefault() || !Guid.Equals(userId, Guid.Empty)) // check User tồn tại hay khum.
            { // nếu User tồn tại thì....
             
                var lstCartItem = _cartItemService.GetAllDataQuery().Where(p => p.UserId == userId).ToList();
                // lấy ra danh sách  các sản phẩm đã thêm vào giỏ hàng.
                var lstCartDto = _mapper.Map<List<CartDto>>(lstCartItem);
               
                //var lstCartDtoNoImage = _mapper.Map<List<CartDto>>(lstCartItem);
                //for (int i = 0; i < lstCartDtoNoImage.Count; i++)
                //{
                //    var Image = _productDetailService.GetProductDetails().Where(p => p.VariantId == lstCartDtoNoImage[i].VariantId).Select(p => p.Images);
                //    lstCartDtoNoImage[i].ImageProduct = Image);
                //}
                return lstCartDto; // trả List Sản phẩm hiển thị.
            }
            else
            {
                //nếu User không tồn tại thì trả về null
                return null;
            }
        }

        public bool RemoveItemIncart(Guid cartId)
        {
            if (cartId.IsNullOrDefault() || Guid.Equals(cartId, Guid.Empty)) // checks null đầu vào.
                return false;
            var itemCart = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.CartId == cartId); // tìm sản phẩm trong giỏ hàng thông qua Cart Id.
            if (itemCart != null)
            {
                //nếu sản phẩm  tồn tại trong giỏ hàng thì Xóa sản phẩm đó trong giỏ hàng.
                _cartItemService.DeleteDataCommand(itemCart);
                return true;
            }
            else
            {//nếu Sản Phẩm không tồn tại thì xóa không thành công.
                return false;
            }
        }
 
        public bool UpdateCart(UpdateCartViewModel cart)
        {
          // 115 đến 118 check giá trị đầu vào.
            if (cart.VariantId.IsNullOrDefault() || Guid.Equals(cart.VariantId, Guid.Empty)) return false;
            if (cart.UserId.IsNullOrDefault() || Guid.Equals(cart.UserId, Guid.Empty)) return false;
            if (cart.Quantity <0) return false;
           
          
            var itemInCartItem = _cartItemService.GetAllDataQuery().FirstOrDefault(p => p.CartId.Equals(cart.CartId));
            // tìm kiếm Sản phẩm muốn update theo IdCart
            if (itemInCartItem.IsNullOrDefault()) return false; // nếu KHông tồn tại thì  trả Về False

            // nếu tồn tại thì update Sản Phẩm trong GIỏ hàng
            itemInCartItem.Quantity = cart.Quantity;
            _cartItemService.UpdateDataCommand(itemInCartItem); 
            return true;


        }
    }
}
