using FoodDeliveryService.DataAccess.DataOperation;
using RestaurantService.Domain.Entities;

namespace RestaurantService.Domain.Repositories
{
    public interface IRestaurantServiceRepository
    {
        public Task<DataOperationResult> CreateTicket(TicketDetails ticketDetails);
        public Task<Ticket> GetTicketById(Guid orderId);
        public Task<DataOperationResult> UpdateTicketStatus(Guid orderId, TicketStatus ticketStatus);
    }
}
