using BUS.Dtos;

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
        public List<OptionDto>? option { get; set; }
    }
}
