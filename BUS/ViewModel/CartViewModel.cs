using DAL.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ViewModel
{
    public class CartViewModel
    {
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public string ProductName { get; set; }
        public ICollection<ImageValueObject> Images { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
