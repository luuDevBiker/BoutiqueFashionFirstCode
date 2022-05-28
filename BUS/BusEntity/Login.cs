using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BUS.BusEntity
{
    public class Login
    {
        public user user { get; set; }
        public RolesUser rolesUser { get; set; }
        public Login()
        {
            rolesUser = new RolesUser();
            user = new user();
        }

        public Login(user user, RolesUser rolesUser)
        {
            this.user = user;
            this.rolesUser = rolesUser;
        }
    }
}
