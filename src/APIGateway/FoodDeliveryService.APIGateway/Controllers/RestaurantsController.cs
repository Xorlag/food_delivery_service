using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantService.Proxy;

namespace FoodDeliveryService.APIGateway.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        [HttpPost("tickets/{orderId}/accept")]
        public async Task<IActionResult> AcceptTicket(Guid orderId,
            [FromServices] IRestaurantServiceProxy restaurantServiceProxy)
        {
            await restaurantServiceProxy.AcceptTicket(orderId);
            return Ok();
        }
    }
}
