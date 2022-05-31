using System;
using System.Collections;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class user
    {
        public Guid userID { get; set; }
        public Guid rolesID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int Gender { get; set; }
        public int? birdDate { get; set; }
        public string? address { get; set; }
        public string numberPhone { get; set; }
        public string email { get; set; }
        public bool isUserEnabled { get; set; }
        public RolesUser rolesUsers { get; set; }
        public ICollection<cart> carts { get; set; }


    }
}
