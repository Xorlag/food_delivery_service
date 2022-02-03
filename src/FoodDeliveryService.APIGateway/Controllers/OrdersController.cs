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
        public IActionResult CreateOrder([FromServices]OrderServiceClient orderServiceClient)
        {
            return Ok();
        }
    }
}
