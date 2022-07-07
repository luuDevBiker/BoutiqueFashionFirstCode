using BUS.Dtos;
using BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Interfaces
{
    public interface IManageService
    {
        public Task<bool> AddUser(CreatUserViewModel creatUser);
        public Task<bool> DeleteUser(Guid userId);
        public Task<UserDto> GetUserDtoDetail(Guid userId);
        public Task<List<UserDto>> GetUsers(Guid userId);
        public Task<bool> UpdateUser(UpdateUserViewModel updateUserViewModel);

    }
}
