﻿
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.BusEntity
{
    public class Cart
    {
        public user User { get; set; }
        public CartItem CartItem { get; set; }
        public bool StatusOrder { get; set; }
    }
}