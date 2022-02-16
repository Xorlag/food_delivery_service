namespace FoodDeliveryService.APIGateway.DTO.Entities
{
    public class OrderLineItemDTO
    {
        public Guid MenuLineItemId { get; set; }
        public int Quantity { get; set; }
    }
}
