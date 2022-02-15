namespace FoodDeliveryService.APIGateway.InboundAdapters.DTO.Entities
{
    public class OrderLineItemDTO
    {
        public Guid MenuLineItemId { get; set; }
        public int Quantity { get; set; }
    }
}
