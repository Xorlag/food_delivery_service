namespace OrderService.DTO.Entities
{
    public class OrderDetailsDTO
    {
        public Guid OrderId { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
        public IEnumerable<OrderLineItemDTO> OrderLineItems { get; set; }
        public DeliveryInfoDTO DeliveryInfo { get; set; }
    }
}
