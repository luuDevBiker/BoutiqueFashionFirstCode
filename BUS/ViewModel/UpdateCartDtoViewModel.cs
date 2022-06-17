using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ViewModel
{
    public class UpdateCartDtoViewModel
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public Guid VariantId { get; set; }
      
        public int Quantity { get; set; }
       
        public bool IsOrderDetailEnabled { get; set; }
        public ProfileViewModel ProfileViewModel { get; set; }
    }
}
