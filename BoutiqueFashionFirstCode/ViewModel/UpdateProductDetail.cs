using BUS.BusEntity;
using DAL.Entities;

namespace BoutiqueFashionFirstCode.ViewModel
{
    public class UpdateProductDetail
    {
        public Guid productId { get; set; }
        public Guid VariantId { get; set; }

        public string productsName { get; set; }
        public Guid skuId { get; set; }
        public float importPrice { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public ICollection<ImageProducts>? Images { get; set; }
        public List<Option>? option { get; set; }
    }
}
