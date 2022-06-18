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
        public OrderDto AddOrders(AddOrderViewModel addOrderViewModel)
        {
            return _orderService.AddOrders(addOrderViewModel.createOrderViewModel, addOrderViewModel.profileViewModel);
        }
        [HttpPut("UpdateOrder")]
        public UpdateCartDto UpdateOrder(UpdateCartDtoViewModel updateCartViewModel)
        {
            return _orderService.UpdateOrders(updateCartViewModel);
        }
        [HttpDelete("DeleteOrder")]
        public bool DeleteOrder([FromBody] Guid orderId)
        {
            return _orderService.DeleteOrder(orderId);
        }
        [HttpDelete("DeleteOrderDetail")]
        public bool DeleteOrderDetail([FromBody] DeleteOrderDetailViewModel deleteOrder)
        {
            return _orderService.DeleteOrderDetail(deleteOrder);
        }
    }
}
