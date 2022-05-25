using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class cart
    {
        public Guid cartID { get; set; }
        public Guid userID { get; set; }
      
        public DateTime orderTime { get; set; }
        public float amountPlay { get; set; }
        public float payingCustomer { get; set; }
        public float refunds { get; set; }
        public float payments { get; set; }
        public bool statusDelete { get; set; }
        public bool isOrderEnabled { get; set; }
        public user user { get; set; }
        public ICollection<cartDetails> cartDetails { get; set; }

    }
}
