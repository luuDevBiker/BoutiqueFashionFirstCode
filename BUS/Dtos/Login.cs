using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BUS.Dtos
{
    public class Login
    {
        public user User { get; set; }
        public RolesUser RolesUser { get; set; }
        public Login()
        {
            RolesUser = new RolesUser();
            User = new user();
        }

        public Login(user user, RolesUser rolesUser)
        {
            this.User = user;
            this.RolesUser = rolesUser;
        }
    }
}
