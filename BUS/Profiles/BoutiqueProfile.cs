using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using BUS.Dtos;

using BUS.ViewModel;
using DAL.Entities;
using DAL.ValueObject;

namespace BUS.Profiles
{
    public class BoutiqueProfile : Profile
    {
        public BoutiqueProfile()
        {
            CreateMap<CartItem, CreatCartViewModel>().ReverseMap();
            CreateMap<CartItem, CartDto>().ReverseMap();
            CreateMap<user, LoginDto>().ReverseMap();
            CreateMap<user, UserDto>().ReverseMap();
            CreateMap<UserDto, CreatUserViewModel>().ReverseMap();
            CreateMap<UserDto, UpdateUserViewModel>().ReverseMap();
            CreateMap<ProfileDto, ProfileViewModel>().ReverseMap();
            CreateMap<ProfileDto, ProfilesUser>().ReverseMap();

        }
    }
}
