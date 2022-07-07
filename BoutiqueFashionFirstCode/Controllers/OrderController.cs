using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using BUS.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public Task<OrderDto> AddOrders([FromBody] AddOrderViewModel addOrderViewModel)
        {
            return _orderService.AddOrders(addOrderViewModel.createOrderViewModel, addOrderViewModel.profileViewModel);
        }
        [HttpPut("UpdateOrder")]
        [Authorize]
        public Task<UpdateCartDto> UpdateOrder([FromBody]UpdateCartDtoViewModel updateCartViewModel)
        {
            return _orderService.UpdateOrders(updateCartViewModel);
        }
        [HttpPut("UpdateProfile")]
        [Authorize]
        public Task<UpdateProfileOrderDto> UpdateProfile([FromBody]UpdateProfileOrderViewModel updateProfileOrder)
        {
            return _orderService.UpdateProfile(updateProfileOrder);
        }
        [HttpDelete("DeleteOrder/{orderId}")]
        [Authorize]
        public Task<bool> DeleteOrder(Guid orderId)
        {
            return _orderService.DeleteOrder(orderId);
        }
        [HttpDelete("DeleteOrderDetail")]
        [Authorize]
        public Task<bool> DeleteOrderDetail([FromBody] DeleteOrderDetailViewModel deleteOrder)
        {
            return _orderService.DeleteOrderDetail(deleteOrder);
        }
        [HttpGet("GetOrderClient/{userId}")]
        [Authorize]
        public List<GetOrder> GetOrderClient([FromODataUri]Guid userId)
        {
            return _orderService.GetOrderClient(userId);
        }
        [HttpGet("GetOrderAdmin")]
        [Authorize(Roles = "Admin")]
        public List<GetOrder> GetOrderAdmin(ODataQueryOptions<GetOrder> queryOptions)
        {
            return _orderService.GetOrderAdmin();
        }
    }
}
