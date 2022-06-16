using DAL.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.ViewModel
{
    public class UpdateUserViewModel
    {
        public Guid UserID { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string GenderStr { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsUserEnabled { get; set; }
        public ImageValueObject Avatar { get; set; }
    }
}
