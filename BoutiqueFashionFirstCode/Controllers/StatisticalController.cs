using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

namespace BoutiqueFashionFirstCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalController : ControllerBase
    {
        private readonly IStatisticalService _statisticalService;
        public StatisticalController(IStatisticalService statisticalService)
        {
            _statisticalService = statisticalService ?? throw new ArgumentNullException(nameof(statisticalService));
        }
        [HttpGet("lstSell/{userId}")]
        [Authorize(Roles = "Admin")]
        public List<StatisticalProduction> Bestseller([FromODataUri]Guid userId)
        {
            return _statisticalService.Bestseller(userId);
        }
        [HttpGet("lstCustomer/{userId}")]
        [Authorize(Roles = "Admin")]
        public List<StatisticalCustomer> BestCustomer([FromODataUri]Guid userId)
        {
            return _statisticalService.BestCustomer(userId);
        }
    }
}
