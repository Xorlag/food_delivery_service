using Microsoft.AspNetCore.Mvc;
using FoodDeliveryService.APIGateway.Core.Mappers;
using FoodDeliveryService.APIGateway.Core.Models.DomainCommands;
using FoodDeliveryService.APIGateway.InboundAdapters.DTO.Requests;
using FoodDeliveryService.APIGateway.Services.OrderService;

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
