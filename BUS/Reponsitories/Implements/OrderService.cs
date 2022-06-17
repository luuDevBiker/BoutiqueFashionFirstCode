using AutoMapper;
using BUS.Dtos;
using BUS.Reponsitories.Interfaces;
using BUS.ViewModel;
using DAL.Entities;
using DAL.Reponsitories.Interfaces;
using DAL.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<user> _userRepository;
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<user> userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public ProfileDto AddProfile(Guid userId, ProfileViewModel profileViewModel)
        {
            var user = _userRepository.GetAllDataQuery().FirstOrDefault(p => p.UserID == userId);
            var profileUser = user.Profile;
            var profileDto = _mapper.Map<ProfileDto>(profileViewModel);
            profileDto.Address = profileViewModel.Address + ", xã/phường" + profileViewModel.Wards + ", quận/huyện" + profileViewModel.District + ", tỉnh/Tp " + profileViewModel.Province;
            var profileExist = user.Profile.Any(p => p.FullName == profileViewModel.FullName && p.Email == profileViewModel.Email && p.PhoneNumber == profileViewModel.PhoneNumber && p.Address == profileDto.Address);
            var profileEnity = _mapper.Map<ProfilesUser>(profileDto);
            if (!profileExist)
            {
                profileUser.Add(profileEnity);
            }
            user.Profile = profileUser;
            _userRepository.UpdateDataCommand(user);
            return profileDto;
        }
    }
}
