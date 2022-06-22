using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ViewModel
{
    public class UpdateCartViewModel
    {
       
       
        public Guid VariantId { get; set; }
      
        public int Quantity { get; set; }
      
        public Guid UserId { get; set; }
        public Guid CartId { get; set; }
    }
}
