using DAL.Entities;
using DAL.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Dtos
{
    public class CartDto
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public ICollection<ImageValueObject> Images { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
