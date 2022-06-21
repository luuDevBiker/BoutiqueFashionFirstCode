using BUS.Dtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Interfaces
{
    public interface IStatisticalService
    {
        public List<StatisticalProduction> Bestseller(Guid userId);
        public List<StatisticalCustomer> BestCustomer(Guid userId);


    }
}
