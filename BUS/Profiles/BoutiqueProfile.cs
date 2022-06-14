using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using BUS.BusEntity;
using BUS.ViewModel;
using DAL.Entities;

namespace BUS.Profiles
{
    public class BoutiqueProfile : Profile
    {
        public BoutiqueProfile()
        {
            CreateMap<CartItem, CreatCartViewModel>().ReverseMap();
            CreateMap<CartItem, CartDto>().ReverseMap();
          
        }
    }
}
