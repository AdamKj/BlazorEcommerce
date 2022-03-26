﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.DTO
{
    public class CartProductResponseDTO
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductType { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
