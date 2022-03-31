namespace BlazorEcommerce.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        public OrderService(DataContext context, ICartService cartService, IAuthService authService)
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
        }

        public async Task<ServiceResponse<bool>> PlaceOrder(int id)
        {
            var products = (await _cartService.GetDbCartProducts(id)).Data;
            double totalPrice = 0;
            products.ForEach(product => totalPrice += product.Price * product.Quantity);

            var orderItems = new List<OrderItem>();
            products.ForEach(product => orderItems.Add(new OrderItem
            {
                ProductId = product.ProductId,
                ProductTypeId = product.ProductTypeId,
                Quantity = product.Quantity,
                TotalPrice = product.Price * product.Quantity
            }));

            var order = new Order()
            {
                UserId = id,
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(_context.CartItems
                .Where(ci => ci.UserId == id));

            _context.SaveChangesAsync();

            return new ServiceResponse<bool> {Data = true};
        }

        public async Task<ServiceResponse<List<OrderOverviewResponseDTO>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponseDTO>>();
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponseDTO>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewResponseDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Product = o.OrderItems.Count > 1 ? 
                    $"{o.OrderItems.First().Product.Title} and " + 
                    $"{o.OrderItems.Count - 1} more products..." : 
                    o.OrderItems.First().Product.Title, 
                ProductImageUrl = o.OrderItems.First().Product.ImageUrl
            }));

            response.Data = orderResponse;

            return response;
        }

        public async Task<ServiceResponse<OrderDetailsResponseDTO>> GetOrderDetails(int id)
        {
            var response = new ServiceResponse<OrderDetailsResponseDTO>();
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.ProductType)
                .Where(o => o.UserId == _authService.GetUserId() && o.Id == id)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();

            if (order is null)
            {
                response.Success = false;
                response.Message = "Order not found.";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponseDTO
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Products = new List<OrderDetailsProductResponseDTO>()
            };

            order.OrderItems.ForEach(item => 
                orderDetailsResponse.Products.Add(new OrderDetailsProductResponseDTO
                {
                    ProductId = item.ProductId,
                    ImageUrl = item.Product.ImageUrl,
                    ProductType = item.ProductType.Name,
                    Quantity = item.Quantity,
                    Title = item.Product.Title,
                    TotalPrice = item.TotalPrice
                }));

            response.Data = orderDetailsResponse;
            return response;
        }
    }
}
