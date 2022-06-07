using BUS.BusEntity;

namespace BoutiqueFashionFirstCode.ViewModel
{
    public class ProductDetail
    {

        public string productsName { get; set; }
        public float importPrice { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public List<Option>? option { get; set; }
    }
}
