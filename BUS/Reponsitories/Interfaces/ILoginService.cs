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
        public Task<LoginDto> Login(ViewUserLoginViewModel viewUserAfterLogin);
        public Task<RegisterDto> Signup(user user);
        public List<RolesUser> lstRolesUser();
        public Task<bool> ForgotPassword(string email);
        public List<user> lstUser();
    }
}
