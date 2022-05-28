using Microsoft.AspNetCore.Mvc;
using BUS.Reponsitories.Implements;
using BUS.Reponsitories.Interfaces;
using DAL.Entities;
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
        public bool Register(string username, string email, int sdt, string password)
        {
            user userAccount = new user();
            userAccount.userID = Guid.NewGuid();
            userAccount.userName = username;
            userAccount.email = email;
            userAccount.password = password;
            userAccount.numberPhone = sdt;
            userAccount.address = "";
            userAccount.birdDate = 0;
            userAccount.rolesID = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");
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
         return   _loginService.ForgotPassword(mail);
            
        }
    }
}
