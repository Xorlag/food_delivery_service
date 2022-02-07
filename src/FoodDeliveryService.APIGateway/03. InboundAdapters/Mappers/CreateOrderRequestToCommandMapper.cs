using FoodDeliveryService.APIGateway.Core.Mappers;
using FoodDeliveryService.APIGateway.Core.Models.DomainCommands;
using FoodDeliveryService.APIGateway.Core.Models.Entities;
using FoodDeliveryService.APIGateway.InboundAdapters.DTO.Requests;

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
