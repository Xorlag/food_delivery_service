using OrderService.Domain.Models.Entities;

namespace OrderService.Messages
{
    public class CreateOrderCommand
    {

        public Guid OrderId { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderLineItem[] OrderLineItems { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }
    }
}
