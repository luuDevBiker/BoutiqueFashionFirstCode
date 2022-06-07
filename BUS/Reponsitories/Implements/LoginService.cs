using BUS.Reponsitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Reponsitories.Implements;
using DAL.Reponsitories.Interfaces;

namespace BUS.Reponsitories.Implements
{
    public class LoginService : ILoginService
    {

        private readonly IGenericRepository<user> _userService;
        private readonly IGenericRepository<RolesUser> _rolesUserService;
        private readonly SendMailService _sendMailService;
        List<user> _users;
        List<RolesUser> _rolesUsers;
        public LoginService(IGenericRepository<user> userService, SendMailService sendMail, IGenericRepository<RolesUser> rolesUserService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _rolesUserService = rolesUserService ?? throw new ArgumentNullException(nameof(rolesUserService));
            _sendMailService = sendMail ?? throw new ArgumentNullException(nameof(sendMail));
            _users = new List<user>();
            _rolesUsers = new List<RolesUser>();
            lstUser();

        }

        public bool ForgotPassword(string email)
        {

            if (email != null)
            {
                if (_userService.GetAllDataQuery().FirstOrDefault(p => p.email == email) != null)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(_sendMailService.randomstring(4, true));
                    builder.Append(_sendMailService.randomnumber(1000, 9999));
                    builder.Append(_sendMailService.randomstring(2, false));
                    _sendMailService.SendMail(email, builder.ToString());
                    return true;
                }
            }
            return false;

        }

        public bool Login(string account, string password)
        {

            if (account != null && password != null)
            {
                user userlogin = _users.FirstOrDefault(c => c.email == account && c.password == password);
                if (userlogin != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public List<RolesUser> lstRolesUser()
        {
            return _rolesUsers = _rolesUserService.GetAllDataQuery().ToList();
        }

        public List<user> lstUser()
        {
            _users = _userService.GetAllDataQuery().ToList();
            return _users;
        }

        public bool Signup(user user)
        {
            if (user != null)
            {
                if (_users.FirstOrDefault(p => p.email == user.email) == null)
                {
                    _userService.AddDataCommand(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }


    }
}
