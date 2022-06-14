using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.BusEntity
{
    public class ProductDetailsDto
    {
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public string? ProductsName { get; set; }
        public Guid SkuId { get; set; }
        public float ImportPrice { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<ImageProducts>? Images { get; set; }
        public List<Option>? Option { get; set; }
    }
}
