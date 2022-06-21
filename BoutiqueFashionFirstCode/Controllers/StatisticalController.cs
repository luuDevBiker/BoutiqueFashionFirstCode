using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost("lstSell/{userId}")]
        public List<StatisticalProduction> Bestseller(Guid userId)
        {
            return _statisticalService.Bestseller(userId);
        }
        [HttpPost("lstCustomer/{userId}")]
        public List<StatisticalCustomer> BestCustomer(Guid userId)
        {
            return _statisticalService.BestCustomer(userId);
        }
    }
}
