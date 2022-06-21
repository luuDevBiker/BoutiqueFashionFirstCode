using DAL.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Dtos
{
    public class RegisterDto
    {
        public Guid UserID { get; set; }
        public Guid RolesID { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public ImageValueObject? Avatar { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<ProfilesUser>? Profile { get; set; }
        public bool IsUserEnabled { get; set; }
    }
}
