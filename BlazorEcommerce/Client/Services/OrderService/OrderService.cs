using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;

        public OrderService(HttpClient http, AuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager)
        {
            _http = http;
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
        }

        public async Task PlaceOrder()
        {
            if (await IsUserAuthenticated())
                await _http.PostAsync("api/order", null);
            else
                _navigationManager.NavigateTo("login");
        }

        public async Task<List<OrderOverviewResponseDTO>> GetOrders()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponseDTO>>>("api/order");
            return result.Data;
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}
