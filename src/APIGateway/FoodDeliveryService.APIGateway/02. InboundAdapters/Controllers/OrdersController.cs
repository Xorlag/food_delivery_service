using Microsoft.AspNetCore.Mvc;
using FoodDeliveryService.APIGateway.InboundAdapters.DTO.Requests;
using FoodDeliveryService.Mappers;
using OrderService.Proxy;
using OrderService.DTO;

namespace FoodDeliveryService.APIGateway.InboundAdapters.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest createOrderRequest,
            [FromServices] OrderServiceProxy orderServiceProxy,
            [FromServices] IMapper<CreateOrderRequest, OrderDetailsDTO> orderServiceRequestToCommandMapper)
        {
            var orderDetailsDTO = orderServiceRequestToCommandMapper.Map(createOrderRequest);
            await orderServiceProxy.CreateOrder(orderDetailsDTO);
            return Ok();
        }
    }
}
