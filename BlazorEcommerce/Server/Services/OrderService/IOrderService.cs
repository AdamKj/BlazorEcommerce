namespace BlazorEcommerce.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> PlaceOrder(int id);
        Task<ServiceResponse<List<OrderOverviewResponseDTO>>> GetOrders();
        Task<ServiceResponse<OrderDetailsResponseDTO>> GetOrderDetails(int id);
    }
}
