using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Reponsitories.Interfaces;
using DAL.Entities;
using AutoMapper;
using Iot.Core.Extensions;
using BUS.ViewModel;

namespace BUS.Reponsitories.Implements
{
    public class ManageService : IManageService
    {
        private readonly IGenericRepository<user> _userRepository;
        private readonly IGenericRepository<RolesUser> _userRoleRepository;
        private readonly IMapper _mapper;
        public ManageService(IGenericRepository<user> userRepository, IMapper mapper, IGenericRepository<RolesUser> userRoleRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userRoleRepository = userRoleRepository ?? throw new ArgumentNullException(nameof(userRoleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddUser(CreatUserViewModel creatUser)
        {
            var userDto = _mapper.Map<UserDto>(creatUser);
            userDto.Gender = creatUser.GenderStr.Trim().ToLower() == "nam" ? 1 : 0;
            userDto.UserID = Guid.NewGuid();
            var lstRole = _userRoleRepository.GetAllDataQuery().Where(p => p.IsRolesUserEnabled == true).ToList(); 
            var roleId = lstRole.Where(p => p.RolesName.Trim().ToLower() == userDto.RoleName.Trim().ToLower()).Select(p => p.RolesID).FirstOrDefault();
            userDto.RolesID = roleId;
            userDto.IsUserEnabled = true;
            var userEntity = _mapper.Map<user>(userDto);
            userEntity.Password = "123456";
            if (_userRepository.GetAllDataQuery().FirstOrDefault(p => p.Email == creatUser.Email) != null) return false;
            await _userRepository.AddAsync(userEntity);
            return true;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == userId && p.IsUserEnabled == true);
            if (user == null) return false;
            user.IsUserEnabled = false;
            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<UserDto> GetUserDtoDetail(Guid userId)
        {
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == userId && p.IsUserEnabled == true);
            if (user.IsNullOrDefault()) return null;
          
            var roleName = _userRoleRepository.GetAllDataQuery().Where(p => p.RolesID == user.RolesID && p.IsRolesUserEnabled == true).Select(p => p.RolesName).FirstOrDefault();
            var userDto = _mapper.Map<UserDto>(user);
            userDto.RoleName = roleName;
            if (userDto.IsNullOrDefault())
            {
                return null;
            }
            return userDto;
        }

        public async Task<List<UserDto>> GetUsers(Guid userId)
        {
          
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == userId);
            var roleName = _userRoleRepository.GetAllDataQuery().Where(p => p.RolesID == user.RolesID).Select(p => p.RolesName).FirstOrDefault();
            if (user.IsNullOrDefault()) return null;
            if (roleName.Trim().ToLower() == "admin")
            {
                var lstUser = _userRepository.GetAllDataQuery().ToList();
                var lstUserDto = _mapper.Map<List<UserDto>>(lstUser);
                foreach (var userDto in lstUserDto)
                {
                    var roleNameUserDto = _userRoleRepository.GetAllDataQuery().Where(p => p.RolesID == userDto.RolesID).Select(p => p.RolesName).FirstOrDefault();
                    if (roleNameUserDto.IsNullOrDefault()) userDto.RoleName = "Undetermined";
                    userDto.RoleName = roleNameUserDto;
                }
                return lstUserDto;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> UpdateUser(UpdateUserViewModel updateUserViewModel)
        {
            var userDto = _mapper.Map<UserDto>(updateUserViewModel);
            userDto.Gender = updateUserViewModel.GenderStr.Trim().ToLower() == "nam" ? 1 : 0;
            var roleId = _userRoleRepository.GetAllDataQuery().Where(p => p.RolesName.Trim().ToLower() == updateUserViewModel.RoleName.Trim().ToLower()).Select(p => p.RolesID).FirstOrDefault();
            userDto.RolesID = roleId;
            var userEntity = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID.Equals(updateUserViewModel.UserID) && p.IsUserEnabled == true);
            if (userEntity.IsNullOrDefault()) return false;
            userEntity.DOB = userDto.DOB;
            userEntity.Gender = userDto.Gender;
            userEntity.RolesID = roleId;
            userEntity.Address = userDto.Address;
            userEntity.UserName = userDto.UserName;
            userEntity.Avatar = userDto.Avatar;
            userEntity.PhoneNumber = userDto.PhoneNumber;
            userEntity.Email = userDto.Email;
            userEntity.IsUserEnabled = userDto.IsUserEnabled;
            await _userRepository.UpdateAsync(userEntity);
            return true;
        }
    }
}
