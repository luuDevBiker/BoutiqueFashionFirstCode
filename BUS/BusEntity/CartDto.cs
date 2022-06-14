
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.BusEntity
{
    public class CartDto
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

     
    }
}
