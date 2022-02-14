using FoodDeliveryService.DataAccess.DataOperation;
using FoodDeliveryService.DataAccess.Sql.DbConnection;
using RestaurantService.Domain.Entities;
using RestaurantService.Domain.Repositories;
using System.Data;

namespace RestaurantService.DataAccess
{
    public class RestaurantServiceRepository : IRestaurantServiceRepository
    {
        private readonly IDbConnectionFactory<RestaurantServiceRepository> _dbConnectionFactory;

        public RestaurantServiceRepository(IDbConnectionFactory<RestaurantServiceRepository> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<DataOperationResult> CreateTicket(TicketDetails ticketDetails)
        {
            using IDbConnection sqlConnection = _dbConnectionFactory.CreateConnection();
            return null;
        }
    }
}