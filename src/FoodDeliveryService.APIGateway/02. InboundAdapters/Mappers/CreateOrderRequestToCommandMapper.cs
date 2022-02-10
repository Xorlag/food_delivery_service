using FoodDeliveryService.APIGateway.InboundAdapters.DTO.Requests;
using FoodDeliveryService.Mappers;
using OrderService.Domain.Models.Entities;
using OrderService.Messages;

namespace FoodDeliveryService.APIGateway.InboundAdapters.Mappers
{
    public class CreateOrderRequestToCommandMapper : IMapper<CreateOrderRequest, CreateOrderCommand>
    {
        public CreateOrderCommand Map(CreateOrderRequest source)
        {
            return new CreateOrderCommand()
            {
                OrderId = source.OrderId,
                RestaurantId = source.RestaurantId,
                CustomerId = source.CustomerId,
                OrderLineItems = source.OrderLineItems.Select(oli => new OrderLineItem()
                {
                    OrderId = source.OrderId,
                    MenuLineItemId = oli.MenuLineItemId,
                    Quantity = oli.Quantity
                }).ToArray(),
                DeliveryInfo = new DeliveryInfo
                {
                    ApartmentsNumber = source.DeliveryInfo.ApartmentsNumber,
                    BuildingNumber = source.DeliveryInfo.BuildingNumber,
                    City = source.DeliveryInfo.City,
                    Street = source.DeliveryInfo.Street,
                    OrderId = source.OrderId,
                }
            };
        }
    }
}
