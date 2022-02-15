using RestaurantService.DTO;

namespace RestaurantService.Messages
{
    public class CreateTicketCommand
    {
        public TicketDetailsDTO TicketDetails { get; set; }
    }
}