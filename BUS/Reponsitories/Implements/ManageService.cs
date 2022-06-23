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
        public bool AddUser(CreatUserViewModel creatUser)
        {
            var userDto = _mapper.Map<UserDto>(creatUser);
            userDto.Gender = creatUser.GenderStr.Trim().ToLower() == "nam" ? 1 : 0;
            userDto.UserID = Guid.NewGuid();
            var lstRole = _userRoleRepository.GetAllDataQuery().Where(p => p.IsRolesUserEnabled == true).ToList(); ;
            var roleId = lstRole.Where(p => p.RolesName.Trim().ToLower() == userDto.RoleName.Trim().ToLower()).Select(p => p.RolesID).FirstOrDefault();
            userDto.RolesID = roleId;
            userDto.IsUserEnabled = true;
            var userEntity = _mapper.Map<user>(userDto);
            if (userEntity.UserID.IsNullOrDefault() || Guid.Equals(userEntity.UserID, Guid.Empty)) return false;
            if (userEntity.RolesID.IsNullOrDefault() || Guid.Equals(userEntity.RolesID, Guid.Empty)) return false;
            if (userEntity.PhoneNumber.IsNullOrDefault()) return false;
            if (userEntity.UserName.IsNullOrDefault() ) return false;
            if (userEntity.Email.IsNullOrDefault()) return false;
            if (userEntity.PhoneNumber.IsNullOrDefault()) return false;
            if (userEntity.Avatar.IsNullOrDefault()) return false;
            userEntity.Password = "123456";
            if (_userRepository.GetAllDataQuery().FirstOrDefault(p => p.Email == creatUser.Email) != null) return false;
            _userRepository.AddDataCommand(userEntity);
            return true;
        }

        public bool DeleteUser(Guid userId)
        {
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == userId && p.IsUserEnabled == true);
            if (user == null) return false;
            user.IsUserEnabled = false;
            _userRepository.UpdateDataCommand(user);
            return true;
        }

        public UserDto GetUserDtoDetail(Guid userId)
        {
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == userId && p.IsUserEnabled == true);
            if (user.IsNullOrDefault()) return null;
            var ga = _userRoleRepository.GetAllDataQuery().Where(p => p.IsRolesUserEnabled == true).ToList();// thua
            var roleName = _userRoleRepository.GetAllDataQuery().Where(p => p.RolesID == user.RolesID && p.IsRolesUserEnabled == true).Select(p => p.RolesName).FirstOrDefault();
            var userDto = _mapper.Map<UserDto>(user);
            userDto.RoleName = roleName;
            if (userDto.IsNullOrDefault())
            {
                return null;
            }
            return userDto;
        }

        public List<UserDto> GetUsers(Guid userId)
        {
            var lstUserEntity = _userRepository.GetAllDataQuery().Where(p => p.IsUserEnabled == true).AsEnumerable();
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

        public bool UpdateUser(UpdateUserViewModel updateUserViewModel)
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
            userEntity.Avatar=userDto.Avatar;
            userEntity.PhoneNumber = userDto.PhoneNumber;
            userEntity.Email = userDto.Email;
            userEntity.IsUserEnabled=userDto.IsUserEnabled;
            if (userEntity.UserID.IsNullOrDefault() || Guid.Equals(userEntity.UserID, Guid.Empty)) return false;
            if (userEntity.RolesID.IsNullOrDefault() || Guid.Equals(userEntity.RolesID, Guid.Empty)) return false;
            if (userEntity.PhoneNumber.IsNullOrDefault() ) return false;
            if (userEntity.UserName.IsNullOrDefault() ) return false;
            if (userEntity.Email.IsNullOrDefault()) return false;
            if (userEntity.Gender.IsNullOrDefault()) return false;
            _userRepository.UpdateDataCommand(userEntity);
            return true;
        }
    }
}
