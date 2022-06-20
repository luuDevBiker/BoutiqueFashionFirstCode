using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ViewModel
{
    public class UpdateProfileOrderViewModel
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public Guid ProfileId { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Sai định dạng email")]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Wards { get; set; }
    }
}
