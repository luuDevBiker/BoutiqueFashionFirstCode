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
        [HttpGet("CheckLogin/{account}/{password}")]
        public bool CheckLogin([FromRoute]string account, string password)
        {
            return _loginService.Login(account, password);
        }

        // POST api/<LoginController>
        [HttpPost("Register")]
        public bool Register(UserViewModel userView)
        {
            user userAccount = new user();
            userAccount.userID = Guid.NewGuid();
            userAccount.userName = userView.UserName;
            userAccount.email = userView.Email;
            userAccount.password = userView.Password;
            userAccount.numberPhone = userView.PhoneNumber;
            userAccount.address = "";
            userAccount.birdDate = DateTime.Now;
            userAccount.rolesID = Guid.Parse("808F83E9-29EE-4CA7-9B77-77114A495B51");
            return _loginService.Signup(userAccount);
        }
        
        [HttpGet("GetUseCollection")]
        public List<user> GetAcountCollection()
        {
            var a = _loginService.lstUser();
            return a;
        }
        [HttpGet("ForgotPassword/{mail}")]
        public bool ForgotPassword(string mail)
        {
         return   _loginService.ForgotPassword(mail);
            
        }
    }
}
