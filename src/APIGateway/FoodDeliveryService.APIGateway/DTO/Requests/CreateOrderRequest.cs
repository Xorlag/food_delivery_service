using FoodDeliveryService.APIGateway.DTO.Entities;

namespace FoodDeliveryService.APIGateway.DTO.Requests
{
    public class CreateOrderRequest
    {
        public Guid OrderId { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderLineItemDTO[] OrderLineItems { get; set; }
        public DeliveryInfoDTO DeliveryInfo { get; set; }
    }
}
