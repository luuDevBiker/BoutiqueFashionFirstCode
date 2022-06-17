using AutoMapper;
using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using BUS.ViewModel;
using DAL.Entities;
using DAL.Reponsitories.Interfaces;
using DAL.ValueObject;
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
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<user> userRepository, IMapper mapper, IGenericRepository<Order> orderRepository, IGenericRepository<OrderDetails> orderDetailRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _orderDetailRepository = orderDetailRepository ?? throw new ArgumentNullException(nameof(orderDetailRepository));
        }
        public ProfileDto AddProfile(Guid userId, ProfileViewModel profileViewModel)
        {
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == userId);
            var profileUser = user.Profile;
            var profileDto = _mapper.Map<ProfileDto>(profileViewModel);
            profileDto.Address = profileViewModel.Address + ", xã/phường" + profileViewModel.Wards + ", quận/huyện" + profileViewModel.District + ", tỉnh/Tp " + profileViewModel.Province;
            var profileExist = user.Profile.Any(p => p.FullName == profileViewModel.FullName && p.Email == profileViewModel.Email && p.PhoneNumber == profileViewModel.PhoneNumber && p.Address == profileDto.Address);
            var profileEnity = _mapper.Map<ProfilesUser>(profileDto);
            if (!profileExist)
            {
                profileUser.Add(profileEnity);
            }
            user.Profile = profileUser;
            _userRepository.UpdateDataCommand(user);
            return profileDto;
        }
        public OrderDto AddOrders(CreateOrderViewModel createOrderViewModel, ProfileViewModel profileViewModel)
        {
            if (createOrderViewModel.CartViewModel.Count > 0)
            {
                var order = _mapper.Map<Order>(createOrderViewModel);
                order.OrderID = Guid.NewGuid();
                order.OrderTime = DateTime.UtcNow;
                order.IsOrderEnabled = true;
                order.StatusOrder = 1;
                _orderRepository.AddDataCommand(order);
                foreach (var item in createOrderViewModel.CartViewModel)
                {
                    var orderDetail = _mapper.Map<OrderDetails>(item);
                    orderDetail.OrderID = order.OrderID;
                    _orderDetailRepository.AddDataCommand(orderDetail);
                }
                var orderDto = _mapper.Map<OrderDto>(createOrderViewModel);
                var profile = AddProfile(createOrderViewModel.UserID, profileViewModel);
                orderDto.ProfileDto = profile;
                return orderDto;
            }
            else
            {
                throw new ArgumentNullException("Cart null");
            }
        }
        public bool UpdateOrders(UpdateCartDtoViewModel updateCartViewModel)
        {
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == updateCartViewModel.UserId);
            var lstProfileUser = user.Profile.ToList();
            var profile =lstProfileUser.FirstOrDefault(p=>p.OrderId==updateCartViewModel.OrderId);
            var order = _orderRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == updateCartViewModel.OrderId);
            if (order.StatusOrder == 1 && order.IsOrderEnabled == true)
            {
                var orderDetail = _orderDetailRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == updateCartViewModel.OrderId && p.VariantID == updateCartViewModel.VariantId);
                orderDetail.Quantity = updateCartViewModel.Quantity;

                _orderDetailRepository.UpdateDataCommand(orderDetail);
                return true;
            }
            else
            {
                throw new ArgumentNullException("Can't update order");
            }

        }
        public bool DeleteOrder(Guid orderId)
        {
            if (orderId == null) throw new ArgumentNullException("Order null");
            var order = _orderRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == orderId && p.IsOrderEnabled==false);
            if (order == null) throw new ArgumentNullException("Order null");
            order.IsOrderEnabled = false;
            order.StatusOrder = 0;
            _orderRepository.UpdateDataCommand(order);
            return true;
        }
        public bool DeleteOrderDetail(Guid orderDetailId)
        {
            if (orderDetailId == null) throw new ArgumentNullException("Order null");
            var orderDetail = _orderDetailRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == orderDetailId && p.IsOrderDetailEnabled ==true);
            if (orderDetail == null) throw new ArgumentNullException("Order null");
            orderDetail.IsOrderDetailEnabled = false;
            _orderDetailRepository.UpdateDataCommand(orderDetail);
            return true;
        }
    }
}
