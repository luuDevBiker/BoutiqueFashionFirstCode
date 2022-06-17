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
        [HttpGet("Orders")]
        public OrderDto Order(AddOrderViewModel addOrderViewModel)
        {
            return _orderService.AddOrders(addOrderViewModel.createOrderViewModel, addOrderViewModel.profileViewModel);
        }
    }
}
