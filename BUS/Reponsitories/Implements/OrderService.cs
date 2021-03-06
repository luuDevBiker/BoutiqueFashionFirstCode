using AutoMapper;
using BUS.Dtos;
using BUS.Exceptions;
using BUS.Reponsitories.Interfaces;
using BUS.ViewModel;
using DAL.Entities;
using DAL.Reponsitories.Interfaces;
using DAL.ValueObject;
using Iot.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<user> _userRepository;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetails> _orderDetailRepository;
        private readonly IGenericRepository<ProductVariants> _productVariantRepository;
        private readonly IGenericRepository<CartItem> _cartItemRepository;
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<user> userRepository, IMapper mapper, IGenericRepository<Order> orderRepository, IGenericRepository<OrderDetails> orderDetailRepository, IGenericRepository<ProductVariants> productVariantRepository, IGenericRepository<CartItem> cartItemRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _orderDetailRepository = orderDetailRepository ?? throw new ArgumentNullException(nameof(orderDetailRepository));
            _productVariantRepository = productVariantRepository ?? throw new ArgumentNullException(nameof(productVariantRepository));
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        }
        public ProfileDto AddProfile(Guid userId, ProfileViewModel profileViewModel)
        {
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == userId);
            if (user.IsNullOrDefault()) return null;
            var lstProfileUser = new List<ProfilesUser>();
            lstProfileUser = user.Profile;
            var address = profileViewModel.Address + ", xã/phường " + profileViewModel.Wards + ", quận/huyện " + profileViewModel.District + ", tỉnh/Tp " + profileViewModel.Province;
            var profileDtoFromViewModel =_mapper.Map<ProfileDto>(profileViewModel);
            profileDtoFromViewModel.Address = address;
            var profileExist = lstProfileUser.FirstOrDefault(p => p.Address.Equals(address) && p.Email.Equals(profileDtoFromViewModel.Email)&& p.FullName .Equals(profileDtoFromViewModel.FullName) && p.PhoneNumber.Equals(profileDtoFromViewModel.PhoneNumber));
            if (profileExist != null)
            {
                var profileDto = _mapper.Map<ProfileDto>(profileExist);
                return profileDto;
            }
            else
            {
                var profileDto = _mapper.Map<ProfileDto>(profileViewModel);
                profileDto.ProfileId = Guid.NewGuid();
                var profileEntity = _mapper.Map<ProfilesUser>(profileDto);
                lstProfileUser.Add(profileEntity);
                user.Profile = lstProfileUser;
                _userRepository.UpdateDataCommand(user);
                return profileDto;
            }
        }
        public OrderDto AddOrders(CreateOrderViewModel createOrderViewModel, ProfileViewModel profileViewModel)
        {
            if (createOrderViewModel.CartViewModel.Count > 0)
            {
                var order = _mapper.Map<Order>(createOrderViewModel);
                order.OrderID = Guid.NewGuid();
                var profile = AddProfile(createOrderViewModel.UserID, profileViewModel);
                order.OrderTime = DateTime.UtcNow;
                order.IsOrderEnabled = true;
                order.StatusOrder = 1;
                order.ProfileId = profile.ProfileId;
                _orderRepository.AddDataCommand(order);
                foreach (var item in createOrderViewModel.CartViewModel)
                {
                    var orderDetail = _mapper.Map<OrderDetails>(item);
                    orderDetail.OrderID = order.OrderID;
                    orderDetail.UnitPrice = item.Price;
                    orderDetail.IsOrderDetailEnabled = true;
                    _orderDetailRepository.AddDataCommand(orderDetail);
                    var productVariant = _productVariantRepository.GetAllDataQuery().FirstOrDefault(p=>p.VariantID==item.VariantId);
                    productVariant.Quantity = productVariant.Quantity -item.Quantity;
                    _productVariantRepository.UpdateDataCommand(productVariant);
                }
                var orderDto = _mapper.Map<OrderDto>(createOrderViewModel);
               // var profile = AddProfile(createOrderViewModel.UserID, profileViewModel, order.OrderID);
                orderDto.ProfileDto = profile;
                var cartItem = _cartItemRepository.GetAllDataQuery().Where(p => p.UserId.Equals(createOrderViewModel.UserID)).ToList();
                foreach (var item in cartItem)
                {
                    _cartItemRepository.DeleteDataCommand(item);
                }
                return orderDto;
            }
            else
            {
                return null;
            }
        }
        public UpdateCartDto UpdateOrders(UpdateCartDtoViewModel updateCartViewModel)
        {
            if (updateCartViewModel.OrderId.IsNullOrDefault()) return null;
            if (updateCartViewModel.ProductId.IsNullOrDefault()) return null;
            if (updateCartViewModel.VariantId.IsNullOrDefault()) return null;
            if (updateCartViewModel.ProductName.IsNullOrDefault()) return null;
            if (updateCartViewModel.Quantity.IsNullOrDefault()) return null;
            if (updateCartViewModel.UserId.IsNullOrDefault()) return null;
            var order = _orderRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == updateCartViewModel.OrderId);
            if (order == null) return null;
            if (order.StatusOrder != 1) return null;
            var orderDetail = _orderDetailRepository.GetAllDataQuery().FirstOrDefault(p=>p.OrderID== updateCartViewModel.OrderId && p.VariantID == updateCartViewModel.VariantId && p.IsOrderDetailEnabled ==true);
            orderDetail.Quantity = updateCartViewModel.Quantity;
            var updateOrderDto =_mapper.Map<UpdateCartDto>(orderDetail);
            return updateOrderDto;

        }
        public UpdateProfileOrderDto UpdateProfile(UpdateProfileOrderViewModel updateProfileOrderViewModel)
        {
            if (updateProfileOrderViewModel.OrderId.IsNullOrDefault()) return null;
            if (updateProfileOrderViewModel.ProfileId.IsNullOrDefault()) return null;
            if (updateProfileOrderViewModel.Email.IsNullOrDefault()) return null;
            if (updateProfileOrderViewModel.FullName.IsNullOrDefault()) return null;
            if (updateProfileOrderViewModel.PhoneNumber.IsNullOrDefault()) return null;
            if (updateProfileOrderViewModel.Address.IsNullOrDefault()) return null;
            if (updateProfileOrderViewModel.Province.IsNullOrDefault()) return null;
            if (updateProfileOrderViewModel.District.IsNullOrDefault()) return null;
            if (updateProfileOrderViewModel.Wards.IsNullOrDefault()) return null;
            var order = _orderRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == updateProfileOrderViewModel.OrderId);
            if (order == null) return null;
            if (order.StatusOrder != 1) return null;
            var userOrder = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == updateProfileOrderViewModel.UserId);
            if (userOrder.IsNullOrDefault()) return null;
            var lstProfileUser = userOrder.Profile;
            var profileOrder = lstProfileUser.Where(p => p.ProfileId == updateProfileOrderViewModel.ProfileId);
            var profileDto = _mapper.Map<UpdateProfileOrderDto>(profileOrder);
            var address = updateProfileOrderViewModel.Address + ", xã/phường " + updateProfileOrderViewModel.Wards + ", quận/huyện " + updateProfileOrderViewModel.District + ", tỉnh/Tp " + updateProfileOrderViewModel.Province;
            profileDto.Address = address;
            var profileEntity = _mapper.Map<ProfilesUser>(profileDto);
            var indexProfile= lstProfileUser.FindIndex(p=>p.ProfileId==updateProfileOrderViewModel.ProfileId);
            lstProfileUser.Add(profileEntity);
            userOrder.Profile = lstProfileUser;
            _userRepository.UpdateDataCommand(userOrder);
            return profileDto;
        }
        public bool DeleteOrder(Guid orderId)
        {
            if (orderId.IsNullOrDefault() || Guid.Equals(orderId,Guid.Empty)) return false;
            var order = _orderRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == orderId && p.IsOrderEnabled==false);
            if (order == null) return false;
            order.IsOrderEnabled = false;
            order.StatusOrder = 0;
            _orderRepository.UpdateDataCommand(order);
            return true;
        }
        public bool DeleteOrderDetail(DeleteOrderDetailViewModel deleteOrder)
        {
            if (deleteOrder == null) return false;
            var orderDetail = _orderDetailRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == deleteOrder.OrderId && p.VariantID ==deleteOrder.VariantId && p.IsOrderDetailEnabled ==true);
            if (orderDetail == null) return false;
            orderDetail.IsOrderDetailEnabled = false;
            _orderDetailRepository.UpdateDataCommand(orderDetail);
            return true;
        }

        public List<GetOrder> GetOrderClient(Guid userId)
        {
            var lstOrderUser = _orderRepository.GetAllDataQuery().Where(p => p.UserID.Equals(userId) && p.IsOrderEnabled == true).ToList();
            var lstGetOrderDto = _mapper.Map<List<GetOrder>>(lstOrderUser);
            for (int i = 0; i < lstOrderUser.Count; i++)
            {
                var orderId = lstOrderUser[i].OrderID;
                var lstOrderDetail = _orderDetailRepository.GetAllDataQuery().Where(p => p.OrderID.Equals(orderId) && p.IsOrderDetailEnabled.Equals(true)).ToList();
                var lstOrderDetailDto = _mapper.Map<List<GetOrderDetail>>(lstOrderDetail);
                lstGetOrderDto[i].OrderDetails = lstOrderDetailDto;
                var userOrder = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID.Equals(userId));
                if (userOrder.Profile.IsNullOrDefault()) return null;
                var profile = userOrder.Profile.Where(p => p.ProfileId == lstOrderUser[i].ProfileId).ToList();
                if (profile.Count ==0) return null;
                var profileOrder = profile.FirstOrDefault(p => p.ProfileId.Equals(lstOrderUser[i].ProfileId));
                lstGetOrderDto[i].Email = profileOrder.Email;
                lstGetOrderDto[i].FullName = profileOrder.FullName;
                lstGetOrderDto[i].Address = profileOrder.Address;
                lstGetOrderDto[i].PhoneNumber = profileOrder.PhoneNumber;   
            }
            return lstGetOrderDto;
        }

        public List<GetOrder> GetOrderAdmin()
        {
            var lstOrderUser = _orderRepository.GetAllDataQuery().Where(p => p.IsOrderEnabled.Equals(true)).ToList();
            var lstGetOrderDto = _mapper.Map<List<GetOrder>>(lstOrderUser);
            for (int i = 0; i < lstOrderUser.Count; i++)
            {
                var orderId = lstOrderUser[i].OrderID;
                var lstOrderDetail = _orderDetailRepository.GetAllDataQuery().Where(p => p.OrderID.Equals(orderId) && p.IsOrderDetailEnabled.Equals(true)).ToList();
                var lstOrderDetailDto = _mapper.Map<List<GetOrderDetail>>(lstOrderDetail);
                lstGetOrderDto[i].OrderDetails = lstOrderDetailDto;
                var userOrder = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID.Equals(lstOrderUser[i].UserID));
                if (userOrder.Profile !=  null)
                {
                    var profile = userOrder.Profile.Where(p => p.ProfileId == lstOrderUser[i].ProfileId).ToList();
                    var lstProfile = userOrder.Profile;
                    if (profile.Count > 0)
                    {
                        var profileOrder = lstProfile.FirstOrDefault(p => p.ProfileId.Equals(lstOrderUser[i].ProfileId));
                        lstGetOrderDto[i].Email = profileOrder.Email;
                        lstGetOrderDto[i].FullName = profileOrder.FullName;
                        lstGetOrderDto[i].Address = profileOrder.Address;
                        lstGetOrderDto[i].PhoneNumber = profileOrder.PhoneNumber;
                    }
                }
            }
            return lstGetOrderDto;
        }
    }
}
