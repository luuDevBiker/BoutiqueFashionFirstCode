using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.BusEntity
{
    public class Statistical
    {
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
        public List<Option> options { get; set; }
    }
}
