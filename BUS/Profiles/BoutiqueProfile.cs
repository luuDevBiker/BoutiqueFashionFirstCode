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
            CreateMap<Order, CreateOrderViewModel>().ReverseMap();
            CreateMap<OrderDetails,OrderDto>().ReverseMap();
            CreateMap<CreateOrderViewModel,OrderDto>().ReverseMap();
            CreateMap<CartViewModel, OrderDetails>().ReverseMap();
            CreateMap<UpdateCartDto, ProfilesUser>().ReverseMap();
            CreateMap<UpdateCartDto, OrderDetails>().ReverseMap();
            CreateMap<UpdateProfileOrderDto, UpdateProfileOrderViewModel>().ReverseMap();
            CreateMap<UpdateProfileOrderDto, ProfilesUser>().ReverseMap();
            CreateMap<Order, GetOrder>().ReverseMap();
            CreateMap<GetOrderDetail, OrderDetails>().ReverseMap();
        

        }
    }
}
