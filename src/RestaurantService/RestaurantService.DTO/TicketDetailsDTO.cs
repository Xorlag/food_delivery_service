namespace RestaurantService.DTO
{
    public class TicketDetailsDTO
    {
        public Guid OrderId { get; set; }
        public Guid RestaurantId { get; set; }
        public IEnumerable<TicketLineItemDTO> TicketLineItems { get; set; }

    }
}
