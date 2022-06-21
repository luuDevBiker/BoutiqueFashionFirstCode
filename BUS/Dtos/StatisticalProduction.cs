using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Dtos
{
    public class StatisticalProduction
    {
        public string ProductName  { get; set; }
        public Int64 Price  { get; set; }
        public Int32 QuantitySold { get; set; }
        public Int64 TotalSales { get; set; }

    }
}
