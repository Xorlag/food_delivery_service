
namespace RestaurantService.Domain.Entities
{
    public class Ticket
    {
        public int OrderId { get; set; }
        public Guid RestaurantId { get; set; }
        public TicketStatus Status { get; set; }
    }
}
