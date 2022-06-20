using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Dtos
{
    public class GetOrder
    {
        public Guid OrderId { get; set; }
        public Guid UserID { get; set; }
        public Guid ProfileId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime OrderTime { get; set; }
        public List<GetOrderDetail> OrderDetails { get; set; }
        public float AmountPay { get; set; }
    }
}
