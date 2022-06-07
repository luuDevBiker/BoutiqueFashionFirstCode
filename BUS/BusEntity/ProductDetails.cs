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
     public Guid productId { get; set; }
        public Guid VariantId { get; set; }
        public string? productsName { get; set; }
        public Guid skuId { get; set; }
        public float importPrice { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public List<Option>? option { get; set; }
    }
}
