using RestaurantService.DTO.Entities;

namespace RestaurantService.DTO.Messages
{
    public class CreateTicketCommand
    {
        public TicketDetailsDTO TicketDetails { get; set; }
    }
}