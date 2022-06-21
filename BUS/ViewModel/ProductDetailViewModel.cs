using BUS.Dtos;
using DAL.ValueObject;

namespace BUS.ViewModel
{
    public class ProductDetailViewModel
    {

        public string ProductName { get; set; }
        public string SkuId { get; set; }
        public Int64 ImportPrice { get; set; }
        public Int64 Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public ICollection<ImageValueObject>? Images { get; set; }
        public List<OptionDto>? Option { get; set; }
    }
}
