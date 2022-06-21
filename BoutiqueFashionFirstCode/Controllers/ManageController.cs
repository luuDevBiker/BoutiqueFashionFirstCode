using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using BUS.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoutiqueFashionFirstCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly IManageService _manageService;
        public ManageController(IManageService manageService)
        {
            _manageService = manageService ?? throw new ArgumentNullException(nameof(manageService));
        }
        [HttpPost("GetUser/{userId}")]
        public UserDto GetUser(Guid userId)
        {
            return _manageService.GetUserDtoDetail(userId);
        }
        [HttpPost("GetAllUser/{userId}")]
        public List<UserDto> GetAllUser( Guid userId)
        {
            return _manageService.GetUsers(userId);
        }
        [HttpPost("AddUser")]
        public bool AddUser([FromBody] CreatUserViewModel creatUser)
        {
           return  _manageService.AddUser(creatUser);
        }
        [HttpPut("UpdateUser")]
        public bool UpdateUser([FromBody] UpdateUserViewModel updateUserViewModel)
        {
            return _manageService.UpdateUser(updateUserViewModel);
        }
        [HttpDelete("DeleteUser/{userId}")]
        public bool DeleteUser(Guid userId)
        {
            return _manageService.DeleteUser(userId);
        }
    }
}
