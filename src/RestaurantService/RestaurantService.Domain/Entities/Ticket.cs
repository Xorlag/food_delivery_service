
namespace RestaurantService.Domain.Entities
{
    public class Ticket
    {
        public Guid OrderId { get; set; }
        public Guid RestaurantId { get; set; }
        public TicketStatus TicketStatus { get; set; }
    }
}
