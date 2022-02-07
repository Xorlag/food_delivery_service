using FoodDeliveryService.APIGateway.InboundAdapters.DTO.Requests;
using FoodDeliveryService.Mappers;
using OrderService.Domain.Entities;
using OrderService.Messages;

namespace FoodDeliveryService.APIGateway.InboundAdapters.Mappers
{
    public class CreateOrderRequestToCommandMapper : IMapper<CreateOrderRequest, CreateOrderCommand>
    {
        public CreateOrderCommand Map(CreateOrderRequest source)
        {
            return new CreateOrderCommand()
            {
                CommandId = source.CommandId,
                RestaurantId = source.RestaurantId,
                OrderLineItems = source.OrderLineItems.Select(oli => new OrderLineItem()
                {
                    MenuItemId = oli.MenuItemId,
                    Quantity = oli.Quantity
                }).ToArray()
            };
        }
    }
}
