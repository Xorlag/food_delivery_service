using RestaurantService.DTO.Entities;

namespace RestaurantService.Proxy
{
    public interface IRestaurantServiceProxy
    {
        public Task CreateTicket(TicketDetailsDTO ticketDetails);

        public Task AcceptTicket(Guid orderId);
    }
}
