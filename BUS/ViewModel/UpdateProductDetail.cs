using BUS.Dtos;

using DAL.Entities;
using DAL.ValueObject;

namespace BoutiqueFashionFirstCode.ViewModel
{
    public class UpdateProductDetail
    {
        public Guid productId { get; set; }
        public Guid VariantId { get; set; }
        public string productsName { get; set; }
        public string skuId { get; set; }
        public Int64 importPrice { get; set; }
        public Int64 price { get; set; }
        public int quantity { get; set; }
        public ICollection<ImageValueObject>? Images { get; set; }
        public List<OptionDto>? option { get; set; }
    }
}
