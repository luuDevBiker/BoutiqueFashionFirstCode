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
        public float AmountPay { get; set; }
        public float PayingCustomer { get; set; }
        public string Description { get; set; }
        public float Payments { get; set; }
        
        public List<CartViewModel> CartViewModel { get; set; }

    }
}
