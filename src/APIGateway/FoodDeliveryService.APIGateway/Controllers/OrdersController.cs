using Microsoft.AspNetCore.Mvc;
using FoodDeliveryService.Mappers;
using OrderService.Proxy;
using OrderService.DTO.Entities;
using FoodDeliveryService.APIGateway.DTO.Requests;

namespace FoodDeliveryService.APIGateway.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest createOrderRequest,
            [FromServices] IOrderServiceProxy orderServiceProxy,
            [FromServices] IMapper<CreateOrderRequest, OrderDetailsDTO> orderServiceRequestToCommandMapper)
        {
            var orderDetailsDTO = orderServiceRequestToCommandMapper.Map(createOrderRequest);
            await orderServiceProxy.CreateOrder(orderDetailsDTO);
            return Ok();
        }
    }
}
