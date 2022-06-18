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
            var order = _orderRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == updateCartViewModel.OrderId);
            if (order == null) throw new ArgumentNullException("order null");
            var userOrder = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == updateCartViewModel.UserId);
            if (userOrder == null) throw new ArgumentNullException("user null");
            var lstProfileUser = new List<ProfilesUser>();
            lstProfileUser = userOrder.Profile;
            var profileUser = lstProfileUser.FirstOrDefault(p => p.ProfileId == order.ProfileId);
            var address = updateCartViewModel.ProfileViewModel.Address + ", xã/phường " + updateCartViewModel.ProfileViewModel.Wards + ", quận/huyện " + updateCartViewModel.ProfileViewModel.District + ", tỉnh/Tp " + updateCartViewModel.ProfileViewModel.Province;
            bool profileExist = profileUser.Email == updateCartViewModel.ProfileViewModel.Email && profileUser.PhoneNumber == updateCartViewModel.ProfileViewModel.PhoneNumber && profileUser.FullName == updateCartViewModel.ProfileViewModel.FullName && profileUser.Address == address;
            if (profileExist != null)
            {
                var orderDetail = _orderDetailRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID.Equals(updateCartViewModel.OrderId) && p.VariantID == updateCartViewModel.VariantId);
                var productVariant = _productVariantRepository.GetAllDataQuery().FirstOrDefault(p => p.VariantID == orderDetail.VariantID);
                var UpdateCartDto = new UpdateCartDto();
                UpdateCartDto.OrderId = updateCartViewModel.OrderId;
                UpdateCartDto.VariantId = updateCartViewModel.VariantId;
                UpdateCartDto.ProductId = updateCartViewModel.ProductId;
                UpdateCartDto.Quantity = updateCartViewModel.Quantity;
                UpdateCartDto.ProfileId = profileUser.ProfileId;
                UpdateCartDto.ImageProduct = productVariant.Images;
                UpdateCartDto.ProductName = updateCartViewModel.ProductName;
                UpdateCartDto.Price = productVariant.Price;
                UpdateCartDto.FullName = profileUser.FullName;
                UpdateCartDto.PhoneNumber = profileUser.PhoneNumber;
                UpdateCartDto.Address = profileUser.Address;
                UpdateCartDto.Email = profileUser.Email;
                return UpdateCartDto;
            }
            else
            {
                var profileDto = _mapper.Map<ProfileDto>(updateCartViewModel);
                profileDto.Address = address;
                profileDto.ProfileId = Guid.NewGuid();
              
                _userRepository.UpdateDataCommand(userOrder);
                order.ProfileId=profileDto.ProfileId;
            }
            return null;
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
        public bool DeleteOrderDetail(DeleteOrderDetailViewModel deleteOrder)
        {
            if (deleteOrder == null) throw new ArgumentNullException("Order null");
            var orderDetail = _orderDetailRepository.GetAllDataQuery().FirstOrDefault(p => p.OrderID == deleteOrder.OrderId && p.VariantID ==deleteOrder.VariantId && p.IsOrderDetailEnabled ==true);
            if (orderDetail == null) throw new ArgumentNullException("Order null");
            orderDetail.IsOrderDetailEnabled = false;
            _orderDetailRepository.UpdateDataCommand(orderDetail);
            return true;
        }
    }
}
