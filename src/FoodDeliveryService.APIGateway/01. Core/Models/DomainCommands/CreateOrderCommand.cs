using FoodDeliveryService.APIGateway.Core.Models.Entities;

namespace FoodDeliveryService.APIGateway.Core.Models.DomainCommands
{
    public class CreateOrderCommand
    {
        public Guid CommandId { get; set; }
        public int RestaurantId { get; set; }
        public OrderLineItem[] OrderLineItems { get; set; }
    }
}
