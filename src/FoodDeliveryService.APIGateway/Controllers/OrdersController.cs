using FoodDeliveryService.APIGateway.Commands;
using FoodDeliveryService.APIGateway.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryService.APIGateway.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderCommand createOrderCommand,
            [FromServices]OrderServiceClient orderServiceClient)
        {
            await orderServiceClient.CreateOrder(createOrderCommand);
            return Ok();
        }
    }
}
