using FoodDeliveryService.APIGateway.InboundAdapters.DTO.Entities;

namespace FoodDeliveryService.APIGateway.InboundAdapters.DTO.Requests
{
    public class CreateOrderRequest
    {
        public Guid OrderId { get; set; }
        public int RestaurantId { get; set; }
        public OrderLineItemDTO[] OrderLineItems { get; set; }
    }
}
