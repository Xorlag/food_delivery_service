using OrderService.Domain.Entities;

namespace OrderService.Messages
{
    public class CreateOrderCommand
    {
        public Guid OrderId { get; set; }
        public int RestaurantId { get; set; }
        public OrderLineItem[] OrderLineItems { get; set; }
    }
}
