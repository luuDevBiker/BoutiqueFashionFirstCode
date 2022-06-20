﻿using BUS.Dtos;
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
        [HttpGet("GetUser")]
        public UserDto GetUser([FromHeader]Guid userId)
        {
            return _manageService.GetUserDtoDetail(userId);
        }
        [HttpGet("GetAllUser")]
        public List<UserDto> GetAllUser([FromHeader] Guid userId)
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
        [HttpDelete("DeleteUser")]
        public bool DeleteUser([FromHeader]Guid userId)
        {
            return _manageService.DeleteUser(userId);
        }
    }
}
