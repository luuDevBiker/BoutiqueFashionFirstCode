namespace BUS.ViewModel
{
    public class CreatCartViewModel
    {

        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public Guid UserId { get; set; }
    }
}
