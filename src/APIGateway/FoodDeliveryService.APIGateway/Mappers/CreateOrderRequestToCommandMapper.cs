using FoodDeliveryService.APIGateway.DTO.Requests;
using FoodDeliveryService.Mappers;
using OrderService.DTO;

namespace FoodDeliveryService.APIGateway.Mappers
{
    public class CreateOrderRequestToCommandMapper : IMapper<CreateOrderRequest, OrderDetailsDTO>
    {
        public OrderDetailsDTO Map(CreateOrderRequest source)
        {
            return new OrderDetailsDTO
            {
                OrderId = source.OrderId,
                RestaurantId = source.RestaurantId,
                CustomerId = source.CustomerId,
                OrderLineItems = source.OrderLineItems.Select(oli => new OrderLineItemDTO()
                {
                    OrderId = source.OrderId,
                    MenuLineItemId = oli.MenuLineItemId,
                    Quantity = oli.Quantity
                }).ToArray(),
                DeliveryInfo = new DeliveryInfoDTO
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
