using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BUS.BusEntity
{
    public class ProductDetails
    {
     public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public string? ProductsName { get; set; }
        public Guid SkuId { get; set; }
        public float ImportPrice { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public List<Option>? Option { get; set; }
    }
}
