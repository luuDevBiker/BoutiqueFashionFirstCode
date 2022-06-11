using Microsoft.AspNetCore.Mvc;
using BUS.Reponsitories.Implements;
using BUS.Reponsitories.Interfaces;
using DAL.Entities;
using BoutiqueFashionFirstCode.ViewModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoutiqueFashionFirstCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }
        // GET api/<LoginController>/5
        [HttpGet("CheckLogin")]
        public bool CheckLogin(string account, string password)
        {
            return _loginService.Login(account, password);
        }

        // POST api/<LoginController>
        [HttpPost("Register")]
        public bool Register(Register register)
        {
            Guid rolesIDNhanVien = _loginService.lstRolesUser().Where(p => p.RolesName == "Nhân viên").Select(p => p.RolesID).FirstOrDefault();
            user userAccount = new user();
            userAccount.UserID = Guid.NewGuid();
            userAccount.UserName = register.username;
            userAccount.Email = register.email;
            userAccount.Password = register.password;
            userAccount.PhoneNumber = register.sdt;
            userAccount.Address = "";
            userAccount.IsUserEnabled = true;
            userAccount.DOB = DateTime.Parse("2002-01-02");
            userAccount.RolesID = rolesIDNhanVien;
            return _loginService.Signup(userAccount);
        }

        [HttpGet("GetUseCollection")]
        public List<user> GetAcountCollection()
        {
            var a = _loginService.lstUser();
            return a;
        }
        [HttpGet("ForgotPassword")]
        public bool ForgotPassword(string mail)
        {
            return _loginService.ForgotPassword(mail);

        }
    }
}
