
namespace RestaurantService.Domain.Entities
{
    public class TicketDetails
    {
        public Guid OrderId { get; set; }
        public Guid RestaurantId { get; set; }
        public IEnumerable<TicketLineItem> TicketLineItems { get; set; }

    }
}
