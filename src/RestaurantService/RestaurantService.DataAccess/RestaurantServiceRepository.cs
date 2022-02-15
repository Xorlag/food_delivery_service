using System.Data;
using System.Data.SqlClient;
using Dapper;
using FoodDeliveryService.DataAccess.DataOperation;
using FoodDeliveryService.DataAccess.Sql.DbConnection;
using RestaurantService.Domain.Entities;
using RestaurantService.Domain.Repositories;

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
            try
            {
                using IDbConnection sqlConnection = _dbConnectionFactory.CreateConnection();
                sqlConnection.Open();
                using IDbTransaction transaction = sqlConnection.BeginTransaction();
                var createOrderSql = @$"INSERT INTO Tickets(TicketId, RestaurantId, TicketStatus)
                                  VALUES(@orderId, @restaurantId, @ticketStatus)";
                await sqlConnection.ExecuteAsync(createOrderSql, new
                {
                    orderId = ticketDetails.OrderId,
                    restaurantId = ticketDetails.RestaurantId,
                    ticketStatus = TicketStatus.AcceptancePending
                }, transaction);

                var insertTicketLineItemsSql = @$"INSERT INTO TicketLineItems(TicketId, MenuLineItemId, Quantity)
                                  VALUES(@ticketId, @menuLineItemId, @quantity)";

                await sqlConnection.ExecuteAsync(insertTicketLineItemsSql, ticketDetails.TicketLineItems, transaction);

                transaction.Commit();
                return DataOperationResult.Success();
            }
            catch (SqlException ex)
            {
                return new DataOperationResult(DataOperationResultStatus.Failure, message: ex.Message);
            }
        }
    }
}