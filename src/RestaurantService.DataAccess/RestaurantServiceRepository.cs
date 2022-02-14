using Dapper;
using FoodDeliveryService.DataAccess.DataOperation;
using FoodDeliveryService.DataAccess.Sql.DbConnection;
using RestaurantService.Domain.Entities;
using RestaurantService.Domain.Repositories;
using System.Data;
using System.Data.SqlClient;

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
                var createOrderSql = @$"INSERT INTO Tickets(OrderId, RestaurantId, TicketStatus)
                                  VALUES(@orderId, @restaurantId, @ticketStatus)";
                await sqlConnection.ExecuteAsync(createOrderSql, new
                {
                    orderId = ticketDetails.OrderId,
                    restaurantId = ticketDetails.RestaurantId,
                    ticketStatus = TicketStatus.AcceptancePending
                }, transaction);

                var insertOrderLineItemsSql = @$"INSERT INTO TicketLineItems(OrderId, MenuLineItemId, Quantity)
                                  VALUES(@orderId, @menuLineItemId, @quantity)";

                await sqlConnection.ExecuteAsync(insertOrderLineItemsSql, ticketDetails.TicketLineItems, transaction);

                //var insertDeliveryInfoSql = @$"INSERT INTO DeliveryInfo(OrderId, City, Street, BuildingNumber, ApartmentsNumber)
                //                  VALUES(@orderId, @city, @street, @buildingNumber, @apartmentsNumber)";
                //await sqlConnection.ExecuteAsync(insertDeliveryInfoSql, orderDetails.DeliveryInfo, transaction);

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