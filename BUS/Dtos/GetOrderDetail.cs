using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Dtos
{
    public class GetOrderDetail
    {
        public Guid OrderID { get; set; }
        public Guid VariantID { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
