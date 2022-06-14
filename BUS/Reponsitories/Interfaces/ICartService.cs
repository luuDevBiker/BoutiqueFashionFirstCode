﻿using BUS.BusEntity;
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
        public bool AddCart(CartItem cartItem);
        public bool UpdateCart(CartItem cartItem);
        public List<CartItem> GetProductInCart(Guid userId);
        public bool RevoteItemIncart(Guid cartid);
    }
}
