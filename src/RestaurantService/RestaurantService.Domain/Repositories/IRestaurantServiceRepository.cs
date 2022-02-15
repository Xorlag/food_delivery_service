using FoodDeliveryService.DataAccess.DataOperation;
using RestaurantService.Domain.Entities;

namespace RestaurantService.Domain.Repositories
{
    public interface IRestaurantServiceRepository
    {
        public Task<DataOperationResult> CreateTicket(TicketDetails ticketDetails);
    }
}
