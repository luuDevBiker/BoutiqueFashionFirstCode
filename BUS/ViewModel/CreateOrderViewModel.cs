using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ViewModel
{
    public  class CreateOrderViewModel
    {
      
        public Guid UserID { get; set; }
        public Int64 AmountPay { get; set; }
        public Int64 PayingCustomer { get; set; }
        public string Description { get; set; }
        public Int64 Payments { get; set; }
        
        public List<CartViewModel> CartViewModel { get; set; }

    }
}
