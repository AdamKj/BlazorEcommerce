using System.Net;
using BlazorEcommerce.Shared.DTO;
using BlazorEcommerce.Shared.Models;
using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public CartService(ILocalStorageService localStorage, HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _localStorage = localStorage;
            _http = http;
            _authStateProvider = authStateProvider;
        }
        public event Action? OnChange;

        public async Task AddToCart(CartItem item)
        {
            if (await IsUserAuthenticated())
            {
                Console.WriteLine("User is auth");
            }
            else
            {
                Console.WriteLine("User is not auth");
            }

            var cart = await GetCart();

            var sameItem = cart.Find(x => x.ProductId == item.ProductId && x.ProductTypeId == item.ProductTypeId);
            if (sameItem == null)
                cart.Add(item);
            else
                sameItem.Quantity += item.Quantity;

            await _localStorage.SetItemAsync("cart", cart);
            await GetCartItemsCount();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            await GetCartItemsCount();
            var cart = await GetCart();

            return cart;
        }

        public async Task<List<CartProductResponseDTO>> GetCartProducts()
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponseDTO>>>();
            return result.Data;
        }

        public async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart is null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == productId && x.ProductTypeId == productTypeId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorage.SetItemAsync("cart", cart);
                await GetCartItemsCount();
            }
        }

        public async Task UpdateQuantity(CartProductResponseDTO product)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart is null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == product.ProductId && x.ProductTypeId == product.ProductTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = product.Quantity;
                await _localStorage.SetItemAsync("cart", cart);
            }
        }

        public async Task StoreCartItems(bool emptyLocalCart = false)
        {
            var localCart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (localCart is null)
            {
                return;
            }

            await _http.PostAsJsonAsync("api/cart", localCart);

            if (emptyLocalCart)
            {
                await _localStorage.RemoveItemAsync("cart");
            }
        }

        public async Task GetCartItemsCount()
        {
            if (await IsUserAuthenticated())
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/Cart/count");
                var count = result.Data;

                await _localStorage.SetItemAsync<int>("cartItemsCount", count);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                await _localStorage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
            }

            OnChange.Invoke();
        }

        private async Task<List<CartItem>> GetCart()
        {
            return await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new();
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}
