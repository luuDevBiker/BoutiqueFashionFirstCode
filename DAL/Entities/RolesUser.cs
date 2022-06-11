using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class RolesUser
    {
       
        public Guid RolesID { get; set; }
        public string RolesName { get; set; }
        public bool IsRolesUserEnabled { get; set; }
        public ICollection<user> Users { get; set; }
    }
}
