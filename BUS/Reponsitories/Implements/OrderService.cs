using AutoMapper;
using BUS.Dtos;
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
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<user> userRepository, IMapper mapper, IGenericRepository<Order> orderRepository, IGenericRepository<OrderDetails> orderDetailRepository, IGenericRepository<ProductVariants> productVariantRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _orderDetailRepository = orderDetailRepository ?? throw new ArgumentNullException(nameof(orderDetailRepository));
            _productVariantRepository = productVariantRepository ?? throw new ArgumentNullException(nameof(productVariantRepository));
        }
        public ProfileDto AddProfile(Guid userId, ProfileViewModel profileViewModel)
        {
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == userId);
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
                }
                var orderDto = _mapper.Map<OrderDto>(createOrderViewModel);
               // var profile = AddProfile(createOrderViewModel.UserID, profileViewModel, order.OrderID);
                orderDto.ProfileDto = profile;
                return orderDto;
            }
            else
            {
                throw new ArgumentNullException("Cart null");
            }
        }
        public UpdateCartDto UpdateOrders(UpdateCartDtoViewModel updateCartViewModel)
        {
            if (updateCartViewModel.OrderId.IsNullOrDefault()) throw new ArgumentNullException("OrderId null");
            if (updateCartViewModel.ProductId.IsNullOrDefault()) throw new ArgumentNullException("ProductId null");
            if (updateCartViewModel.VariantId.IsNullOrDefault()) throw new ArgumentNullException("VariantId null");
            if (updateCartViewModel.ProductName.IsNullOrDefault()) throw new ArgumentNullException("ProductName null");
            if (updateCartViewModel.Quantity.IsNullOrDefault()) throw new ArgumentNullException("Quantity null");
            if (updateCartViewModel.UserId.IsNullOrDefault()) throw new ArgumentNullException("UserId null");
            var order = _orderRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == updateCartViewModel.OrderId);
            if (order == null) throw new ArgumentException("Order null");
            if (order.StatusOrder != 1) throw new ArgumentException("Order has been shipped");
            var orderDetail = _orderDetailRepository.GetAllDataQuery().FirstOrDefault(p=>p.OrderID== updateCartViewModel.OrderId && p.VariantID == updateCartViewModel.VariantId && p.IsOrderDetailEnabled ==true);
            orderDetail.Quantity = updateCartViewModel.Quantity;
            var updateOrderDto =_mapper.Map<UpdateCartDto>(orderDetail);
            return updateOrderDto;

        }
        public UpdateProfileOrderDto UpdateProfile(UpdateProfileOrderViewModel updateProfileOrderViewModel)
        {
            if (updateProfileOrderViewModel.OrderId.IsNullOrDefault()) throw new ArgumentNullException("OrderId null");
            if (updateProfileOrderViewModel.ProfileId.IsNullOrDefault()) throw new ArgumentNullException("ProfileId null");
            if (updateProfileOrderViewModel.Email.IsNullOrDefault()) throw new ArgumentNullException("Email null");
            if (updateProfileOrderViewModel.FullName.IsNullOrDefault()) throw new ArgumentNullException("FullName null");
            if (updateProfileOrderViewModel.PhoneNumber.IsNullOrDefault()) throw new ArgumentNullException("PhoneNumber null");
            if (updateProfileOrderViewModel.Address.IsNullOrDefault()) throw new ArgumentNullException("Address null");
            if (updateProfileOrderViewModel.Province.IsNullOrDefault()) throw new ArgumentNullException("Province null");
            if (updateProfileOrderViewModel.District.IsNullOrDefault()) throw new ArgumentNullException("District null");
            if (updateProfileOrderViewModel.Wards.IsNullOrDefault()) throw new ArgumentNullException("Wards null");
            var order = _orderRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == updateProfileOrderViewModel.OrderId);
            if (order == null) throw new ArgumentException("Order null");
            if (order.StatusOrder != 1) throw new ArgumentException("Order has been shipped");
            var userOrder = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == updateProfileOrderViewModel.UserId);
            if (userOrder.IsNullOrDefault()) throw new ArgumentException("user null");
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
            if (orderId.IsNullOrDefault() || Guid.Equals(orderId,Guid.Empty)) throw new ArgumentNullException("OrderId null");
            var order = _orderRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == orderId && p.IsOrderEnabled==false);
            if (order == null) throw new ArgumentNullException("Order null");
            order.IsOrderEnabled = false;
            order.StatusOrder = 0;
            _orderRepository.UpdateDataCommand(order);
            return true;
        }
        public bool DeleteOrderDetail(DeleteOrderDetailViewModel deleteOrder)
        {
            if (deleteOrder == null) throw new ArgumentNullException("Order null");
            var orderDetail = _orderDetailRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == deleteOrder.OrderId && p.VariantID ==deleteOrder.VariantId && p.IsOrderDetailEnabled ==true);
            if (orderDetail == null) throw new ArgumentNullException("Order null");
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
                var lstOrderDetail = _orderDetailRepository.GetAllDataQuery().Where(p => p.Equals(orderId) && p.IsOrderDetailEnabled.Equals(true)).ToList();
                var lstOrderDetailDto = _mapper.Map<List<GetOrderDetail>>(lstOrderDetail);
                lstGetOrderDto[i].OrderDetails = lstOrderDetailDto;
                var userOrder = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID.Equals(userId));
                if (userOrder.Profile.IsNullOrDefault()) throw new ArgumentNullException("Can't get profile");
                 var lstProfile = userOrder.Profile;
                var profileOrder = lstProfile.FirstOrDefault(p => p.ProfileId.Equals(lstOrderUser[i].ProfileId));
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
                var lstOrderDetail = _orderDetailRepository.GetAllDataQuery().Where(p => p.Equals(orderId) && p.IsOrderDetailEnabled.Equals(true)).ToList();
                var lstOrderDetailDto = _mapper.Map<List<GetOrderDetail>>(lstOrderDetail);
                lstGetOrderDto[i].OrderDetails = lstOrderDetailDto;
                var userOrder = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID.Equals(lstOrderUser[i].UserID));
                if (userOrder.Profile.IsNullOrDefault()) throw new ArgumentNullException("Can't get profile");
                var lstProfile = userOrder.Profile;
                var profileOrder = lstProfile.FirstOrDefault(p => p.ProfileId.Equals(lstOrderUser[i].ProfileId));
                lstGetOrderDto[i].Email = profileOrder.Email;
                lstGetOrderDto[i].FullName = profileOrder.FullName;
                lstGetOrderDto[i].Address = profileOrder.Address;
                lstGetOrderDto[i].PhoneNumber = profileOrder.PhoneNumber;
            }
            return lstGetOrderDto;
        }
    }
}
