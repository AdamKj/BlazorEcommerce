using BlazorEcommerce.Shared.Models;
using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;

        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        public event Action? OnChange;

        public async Task AddToCart(CartItem item)
        {
            var cart = await GetCart();

            cart.Add(item);

            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await GetCart();

            return cart;
        }

        private async Task<List<CartItem>> GetCart()
        {
            return await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new();
        }
    }
}
