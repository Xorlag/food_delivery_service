namespace RestaurantService.DTO
{
    public class TicketLineItemDTO
    {
        public Guid TicketId { get; set; }
        public Guid MenuLineItemId { get; set; }
        public int Quantity { get; set; }
    }
}
