using BUS.Dtos;
﻿using BUS.BusEntity;
using DAL.Entities;

namespace BoutiqueFashionFirstCode.ViewModel
{
    public class ProductDetail
    {
        public string ProductName { get; set; }
        public float ImportPrice { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<ImageProducts>? Images { get; set; }
        public List<Option>? Option { get; set; }
    }
}
