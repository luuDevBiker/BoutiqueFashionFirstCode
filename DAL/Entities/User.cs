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
        public int Gender { get; set; }
        public int birdDate { get; set; }
        public int address { get; set; }
        public int numberPhone { get; set; }
        public int email { get; set; }
        public int isUserEnabled { get; set; }
        public RolesUser rolesUsers { get; set; }
        public ICollection<cart> carts { get; set; }
    }
}
