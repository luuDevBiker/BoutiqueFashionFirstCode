using Microsoft.AspNetCore.Mvc;
using BUS.Reponsitories.Implements;
using BUS.Reponsitories.Interfaces;
using DAL.Entities;
using BoutiqueFashionFirstCode.ViewModel;
using BUS.ViewModel;
using BUS.Dtos;
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
        [HttpPost("CheckLogin")]
        public LoginDto CheckLogin([FromBody]ViewUserLoginViewModel viewUserLogin)// các Class có tên "ViewModel" ở cuối là các đối tượng chứa các thuộc tính nhận giá trị mà FontEnd vào của phương thức.
                                                                                  // phương thức LOgin( sử dụng Http method Post ). call đến service LOgin.
        {
            return _loginService.Login(viewUserLogin);
        }

        // POST api/<LoginController>
        [HttpPost("Register")]
        public RegisterDto Register(RegisterViewModel register)
        {
            var rolesIDNhanVien = _loginService.lstRolesUser().Where(p => p.RolesName == "Nhân viên").Select(p => p.RolesID).FirstOrDefault();
            var userAccount = new user();
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
        [HttpPost("ForgotPassword/{mail}")]
        public bool ForgotPassword(string mail)
        {
            return _loginService.ForgotPassword(mail);

        }
    }
}
