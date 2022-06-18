using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ViewModel
{
    public class DeleteOrderDetailViewModel
    {
        public Guid OrderId { get; set; }
        public Guid VariantId { get; set; }
    }
}
