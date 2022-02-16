using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantService.Proxy;

namespace FoodDeliveryService.APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        [HttpPost("tickets/{orderId}/accept")]
        public async Task<IActionResult> AcceptTicket(Guid orderId,
            [FromServices] RestaurantServiceProxy restaurantServiceProxy)
        {
            await restaurantServiceProxy.AcceptTicket(orderId);
            return Ok();
        }
    }
}
