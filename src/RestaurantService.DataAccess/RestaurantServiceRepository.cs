using FoodDeliveryService.DataAccess.DataOperation;
using RestaurantService.Domain.Repositories;

namespace RestaurantService.DataAccess
{
    public class RestaurantServiceRepository : IRestaurantServiceRepository
    {
        public RestaurantServiceRepository(string connectionString)
        {
            
        }
        public DataOperationResult CreateTicket(TicketDetails ticketDetails)
        {
            throw new NotImplementedException();
        }
    }
}