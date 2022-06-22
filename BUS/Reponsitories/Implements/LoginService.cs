using BUS.Reponsitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Reponsitories.Implements;
using DAL.Reponsitories.Interfaces;
using BUS.ViewModel;
using BUS.Dtos;
using Iot.Core.Extensions;
using AutoMapper;
using BUS.Exceptions;

namespace BUS.Reponsitories.Implements
{
    public class LoginService : ILoginService
    {

        private readonly IGenericRepository<user> _userService;
        private readonly IGenericRepository<RolesUser> _rolesUserService;
        private readonly SendMailService _sendMailService;
        private readonly IMapper _imapper;
        List<user> _users;
        List<RolesUser> _rolesUsers;
        public LoginService(IGenericRepository<user> userService, SendMailService sendMail, IGenericRepository<RolesUser> rolesUserService, IMapper imapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _rolesUserService = rolesUserService ?? throw new ArgumentNullException(nameof(rolesUserService));
            _sendMailService = sendMail ?? throw new ArgumentNullException(nameof(sendMail));
            _imapper = imapper ?? throw new ArgumentNullException(nameof(imapper));
            _users = new List<user>();
            _rolesUsers = new List<RolesUser>();
            lstUser();
            lstRolesUser();

        }

        public bool ForgotPassword(string email)
        {

            if (email != null)
            {
                if (_userService.GetAllDataQuery().FirstOrDefault(p => p.Email == email) != null)
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

        public LoginDto Login(ViewUserLoginViewModel viewUserAfterLogin)
        {

            if (!viewUserAfterLogin.UserName.IsNullOrDefault() && !viewUserAfterLogin.Password.IsNullOrDefault())
            {
                var userlogin = _users.FirstOrDefault(c => c.UserName == viewUserAfterLogin.UserName && c.Password == viewUserAfterLogin.Password);
                if (userlogin != null)
                {
                    var userDtoHaventRole = _imapper.Map<LoginDto>(userlogin);
                    var roleName = _rolesUsers.Where(p => p.RolesID == userDtoHaventRole.RolesID).Select(p => p.RolesName).FirstOrDefault();
                    if (!roleName.IsNullOrDefault())
                    {
                        userDtoHaventRole.RolesName = roleName;
                        return userDtoHaventRole;
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }
                

            }
            else
            {
                return null;
            }


        }

        public List<RolesUser> lstRolesUser()
        {
            return _rolesUsers = _rolesUserService.GetAllDataQuery().ToList();
        }

        public List<user> lstUser()
        {
            _users = _userService.GetAllDataQuery().Where(p=>p.IsUserEnabled==true).ToList();
            return _users;
        }

        public RegisterDto Signup(user user)
        {
            if (user != null)
            {
                if (_users.FirstOrDefault(p => p.Email == user.Email) != null) return null;
                if (_users.FirstOrDefault(p => p.PhoneNumber == user.PhoneNumber ) != null) return null;
                _userService.AddDataCommand(user);
                var userDto = _imapper.Map<RegisterDto>(user);
                var roleName = _rolesUserService.GetAllDataQuery().Where(p=>p.RolesID==user.RolesID).Select(p=>p.RolesName).FirstOrDefault();
                userDto.RoleName = roleName;
                return userDto;
            }
            else
            {
                return null;
            }

        }


    }
}
