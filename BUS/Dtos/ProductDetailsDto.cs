using DAL.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Dtos
{
    public class ProductDetailsDto
    {
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public string? ProductsName { get; set; }
        public string SkuId { get; set; }
        public float ImportPrice { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public ICollection<ImageValueObject>? Images { get; set; }
        public List<OptionDto>? Option { get; set; }
    }
}
