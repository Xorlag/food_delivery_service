
namespace RestaurantService.Domain.Entities
{
    public class TicketLineItem
    {
        public Guid TicketId { get; set; }
        public Guid MenuLineItemId { get; set; }
        public int Quantity { get; set; }
    }
}
