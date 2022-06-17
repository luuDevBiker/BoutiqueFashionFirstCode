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
        public UserDto GetUserDtoDetail(Guid userId);
        public bool AddUser(CreatUserViewModel creatUser);
        public bool UpdateUser(UpdateUserViewModel updateUserViewModel);
        public bool DeleteUser(Guid userId);
        public List<UserDto> GetUsers(Guid userId);

    }
}
