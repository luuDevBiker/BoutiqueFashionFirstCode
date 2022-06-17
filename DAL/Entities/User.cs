using DAL.ValueObject;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class user
    {
        public Guid UserID { get; set; }
        public Guid RolesID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public ImageValueObject? Avatar { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<ProfilesUser>? Profile { get; set; }
        public bool IsUserEnabled { get; set; }
        public RolesUser RolesUsers { get; set; }
        public ICollection<Order> Orders { get; set; }
     

    }
}
