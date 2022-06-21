using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Dtos;
using BUS.ViewModel;
using DAL.Entities;
namespace BUS.Reponsitories.Interfaces
{
    public interface ILoginService
    {
        public LoginDto Login(ViewUserLoginViewModel viewUserAfterLogin);
        public RegisterDto Signup(user user);
        public List<RolesUser> lstRolesUser();
        public bool ForgotPassword(string email);
        public List<user> lstUser();
    }
}
