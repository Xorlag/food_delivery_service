using Dapper;
using FoodDeliveryService.DataAccess.DataOperation;
using OrderService.Domain.Entities;
using OrderService.Domain.Models.Entities;
using OrderService.Domain.Repository;
using System.Data;
using System.Data.SqlClient;

namespace OrderService.DataAccess
{
    public class OrderServiceRepository : IOrderServiceRepository
    {
        private readonly string _connectionString;

        public OrderServiceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DataOperationResult> CreateOrderAsync(OrderDetails orderDetails)
        {
            try
            {
                using IDbConnection sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                using IDbTransaction transaction = sqlConnection.BeginTransaction();
                var createOrderSql = @$"INSERT INTO Orders(OrderId, CustomerId, RestaurantId, OrderStatus)
                                  VALUES(@orderId, @customerId, @restaurantId, @orderStatus)";
                await sqlConnection.ExecuteAsync(createOrderSql, new
                {
                    orderId = orderDetails.OrderId,
                    customerId = orderDetails.CustomerId,
                    orderStatus = OrderStatus.ApprovalPending,
                    restaurantId = orderDetails.RestaurantId
                }, transaction);

                var insertOrderLineItemsSql = @$"INSERT INTO OrderLineItems(OrderId, MenuLineItemId, Quantity)
                                  VALUES(@orderId, @menuLineItemId, @quantity)";

                await sqlConnection.ExecuteAsync(insertOrderLineItemsSql, orderDetails.OrderLineItems, transaction);

                var insertDeliveryInfoSql = @$"INSERT INTO DeliveryInfo(OrderId, City, Street, BuildingNumber, ApartmentsNumber)
                                  VALUES(@orderId, @city, @street, @buildingNumber, @apartmentsNumber)";
                await sqlConnection.ExecuteAsync(insertDeliveryInfoSql, orderDetails.DeliveryInfo, transaction);

                transaction.Commit();
                return DataOperationResult.Success();
            }
            catch (Exception ex)
            {
                return new DataOperationResult(DataOperationResultStatus.Failure, message: ex.Message);
            }
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var getOrderSql = @"SELECT OrderId, CustomerId, RestaurantId, OrderStatus
                                FROM Orders
                                WHERE OrderId = @orderId";
            var resultOrder = await dbConnection.QueryFirstOrDefaultAsync<Order>(getOrderSql, new
            {
                orderId = orderId
            });
            return resultOrder;
        }

        public Task<DataOperationResult> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}