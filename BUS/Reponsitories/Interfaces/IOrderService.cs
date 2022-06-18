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
        public OrderDto AddOrders(CreateOrderViewModel createOrderViewModel, ProfileViewModel profileViewModel);
        public UpdateCartDto UpdateOrders(UpdateCartDtoViewModel updateCartViewModel);
        public bool DeleteOrder(Guid orderId);
        public bool DeleteOrderDetail(DeleteOrderDetailViewModel deleteOrder);
    }
}
