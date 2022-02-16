namespace RestaurantService.DTO
{
    public class TicketLineItemDTO
    {
        public Guid OrderId { get; set; }
        public Guid MenuLineItemId { get; set; }
        public int Quantity { get; set; }
    }
}
