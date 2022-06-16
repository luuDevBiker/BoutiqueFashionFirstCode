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
        public bool AddCart(CreatCartViewModel cart);
        public List<CartDto> GetProductInCart(Guid userId);
        public bool RevoteItemIncart(Guid cartId);
        public bool UpdateCart(UpdateCartViewModel cart);
    }
}
