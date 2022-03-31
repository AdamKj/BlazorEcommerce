using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OrderOverviewResponseDTO>>>> GetOrders()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<OrderDetailsResponseDTO>>> GetOrdersDetails(int id)
        {
            var result = await _orderService.GetOrderDetails(id);
            return Ok(result);
        }
    }
}
