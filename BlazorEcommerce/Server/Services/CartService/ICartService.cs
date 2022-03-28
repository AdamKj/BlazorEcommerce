﻿using BlazorEcommerce.Shared.DTO;
using BlazorEcommerce.Shared.Models;

namespace BlazorEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponseDTO>>> GetCartProducts(List<CartItem> cartItems);
        Task<ServiceResponse<List<CartProductResponseDTO>>> StoreCartItems(List<CartItem> cartItems, int userId);
    }
}
