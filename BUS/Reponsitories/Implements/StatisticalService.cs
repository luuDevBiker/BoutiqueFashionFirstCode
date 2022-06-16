using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using DAL.Entities;
using DAL.Reponsitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Implements
{
    public class StatisticalService : IStatisticalService
    {
        private readonly IGenericRepository<Order> _orderService;
        private readonly IGenericRepository<OrderDetails> _orderDetailService;
        public StatisticalService(IGenericRepository<Order> orderService, IGenericRepository<OrderDetails> orderDetailService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _orderDetailService = orderDetailService ?? throw new ArgumentNullException(nameof(_orderDetailService));
        }

        public List<Statistical> Bestseller(DateTime first, DateTime last, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
