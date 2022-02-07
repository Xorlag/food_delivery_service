using Microsoft.AspNetCore.Mvc;
using FoodDeliveryService.APIGateway.InboundAdapters.DTO.Requests;
using FoodDeliveryService.APIGateway.Services.OrderService;
using OrderService.Messages;
using FoodDeliveryService.Mappers;

namespace FoodDeliveryService.APIGateway.InboundAdapters.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest createOrderRequest,
            [FromServices] OrderServiceClient orderServiceClient,
            [FromServices] IMapper<CreateOrderRequest, CreateOrderCommand> orderServiceRequestToCommandMapper)
        {
            var createOrderCommand = orderServiceRequestToCommandMapper.Map(createOrderRequest);
            await orderServiceClient.CreateOrder(createOrderCommand);
            return Ok();
        }
    }
}
