using FoodDeliveryService.APIGateway.InboundAdapters.DTO.Entities;

namespace FoodDeliveryService.APIGateway.InboundAdapters.DTO.Requests
{
    public class CreateOrderRequest
    {
        public Guid CommandId { get; set; }
        public int RestaurantId { get; set; }
        public OrderLineItemDTO[] OrderLineItems { get; set; }
    }
}
