using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class RolesUser
    {
       
        public Guid rolesID { get; set; }
        public string rolesName { get; set; }
        public bool isRolesUserEnabled { get; set; }
        public ICollection<user> users { get; set; }
    }
}
