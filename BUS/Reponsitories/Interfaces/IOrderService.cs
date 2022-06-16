using BUS.Dtos;
using BUS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Interfaces
{
    public  interface IOrderService
    {
        public ProfileDto AddProfile(Guid userId, ProfileViewModel profileViewModel);
    }
}
