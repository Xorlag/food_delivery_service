using FoodDeliveryService.DataAccess.DataOperation;
using RestaurantService.Domain.Entities;
using System.Threading.Tasks;

namespace RestaurantService.Domain.Repositories
{
    public interface IRestaurantServiceRepository
    {
        public Task<DataOperationResult> CreateTicket(TicketDetails ticketDetails);
    }
}
