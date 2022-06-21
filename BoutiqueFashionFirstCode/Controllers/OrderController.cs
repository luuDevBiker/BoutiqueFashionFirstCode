using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using BUS.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoutiqueFashionFirstCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        [HttpPost("AddOrders")]
        public OrderDto AddOrders([FromBody] AddOrderViewModel addOrderViewModel)
        {
            return _orderService.AddOrders(addOrderViewModel.createOrderViewModel, addOrderViewModel.profileViewModel);
        }
        [HttpPut("UpdateOrder")]
        public UpdateCartDto UpdateOrder([FromBody]UpdateCartDtoViewModel updateCartViewModel)
        {
            return _orderService.UpdateOrders(updateCartViewModel);
        }
        [HttpPut("UpdateProfile")]
        public UpdateProfileOrderDto UpdateProfile([FromBody]UpdateProfileOrderViewModel updateProfileOrder)
        {
            return _orderService.UpdateProfile(updateProfileOrder);
        }
        [HttpDelete("DeleteOrder/{orderId}")]
        public bool DeleteOrder(Guid orderId)
        {
            return _orderService.DeleteOrder(orderId);
        }
        [HttpDelete("DeleteOrderDetail")]
        public bool DeleteOrderDetail([FromBody] DeleteOrderDetailViewModel deleteOrder)
        {
            return _orderService.DeleteOrderDetail(deleteOrder);
        }
        [HttpPost("GetOrderClient/{userId}")]
        public List<GetOrder> GetOrderClient(Guid userId)
        {
            return _orderService.GetOrderClient(userId);
        }
        [HttpGet("GetOrderAdmin")]
        public List<GetOrder> GetOrderAdmin()
        {
            return _orderService.GetOrderAdmin();
        }
    }
}
