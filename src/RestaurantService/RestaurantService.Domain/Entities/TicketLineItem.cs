
namespace RestaurantService.Domain.Entities
{
    public class TicketLineItem
    {
        public Guid OrderId { get; set; }
        public Guid MenuLineItemId { get; set; }
        public int Quantity { get; set; }
    }
}
