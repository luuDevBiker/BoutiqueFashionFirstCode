using DAL.ValueObject;

namespace BUS.ViewModel
{
    public class CreatCartViewModel
    {

      
        public Guid VariantId { get; set; }
       
      
        public int Quantity { get; set; }
      
        public Guid UserId { get; set; }
    }
}
