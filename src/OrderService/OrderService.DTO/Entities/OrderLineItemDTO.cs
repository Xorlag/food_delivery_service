namespace OrderService.DTO.Entities
{
    public class OrderLineItemDTO
    {
        public Guid OrderId { get; set; }
        public Guid MenuLineItemId { get; set; }
        public int Quantity { get; set; }
    }
}
