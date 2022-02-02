using FoodDeliveryService.APIGateway.Commands.Models;

namespace FoodDeliveryService.APIGateway.Commands
{
    public class CreateOrderCommand
    {
        public Guid CommandId { get; set; }
        public int RestaurantId { get; set; }
        public OrderLineItem[] OrderLineItems { get; set; }
    }
}
