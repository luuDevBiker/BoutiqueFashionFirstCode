using BUS.Profiles;
using BUS.Dtos;
using BUS.ViewModel;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Interfaces
{
    public interface ICartService
    {
        public Task<bool> AddCart(CreatCartViewModel cart);
        public Task<bool> RevoteItemIncart(Guid cartId);
        public Task<bool> UpdateCart(UpdateCartViewModel cart);
        public List<CartDto> GetProductInCart(Guid userId);


    }
}
