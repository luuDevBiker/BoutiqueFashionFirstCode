using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using BUS.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

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
        [HttpGet("GetUser/{userId}")]
        public UserDto GetUser([FromODataUri] Guid userId)
        {
            return _manageService.GetUserDtoDetail(userId);
        }
        [HttpGet("GetAllUser/{userId}")]
        public List<UserDto> GetAllUser([FromODataUri]  Guid userId)
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
