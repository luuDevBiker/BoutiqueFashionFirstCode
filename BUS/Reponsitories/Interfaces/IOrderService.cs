using BUS.Dtos;
using BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Interfaces
{
    public  interface IOrderService
    {
        public ProfileDto AddProfile(Guid userId, ProfileViewModel profileViewModel);
        public Task<OrderDto> AddOrders(CreateOrderViewModel createOrderViewModel, ProfileViewModel profileViewModel);
        public Task<UpdateProfileOrderDto> UpdateProfile(UpdateProfileOrderViewModel updateProfileOrderViewModel);
        public Task<bool> DeleteOrder(Guid orderId);
        public Task<bool> DeleteOrderDetail(DeleteOrderDetailViewModel deleteOrder);
        public Task<UpdateCartDto> UpdateOrders(UpdateCartDtoViewModel updateCartViewModel);
        public List<GetOrder> GetOrderClient(Guid userId);
        public List<GetOrder> GetOrderAdmin();
    }
}
