using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Dtos
{
    public class StatisticalCustomer
    {
        public string CustomerName { get; set; }
        public int QuantityOrder { get; set; }
        public Int64 TotalMoney { get; set; }
        public int QuantityProduct { get; set; }

    }
}
