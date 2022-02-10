using Dapper;
using FoodDeliveryService.DataAccess.DataOperation;
using OrderService.Domain.Entities;
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

        public async Task<DataOperationResult> CreateOrderAsync(OrderDetails order)
        {
            try
            {
                using IDbConnection sqlConnection = new SqlConnection(_connectionString);
                var sqlQuery = @$"INSERT INTO Orders(OrderId, CustomerId, OrderStatus)
                                  VALUES(@orderId, @customerId, @orderStatus)";
                await sqlConnection.ExecuteAsync(sqlQuery, new
                {
                    orderId = order.OrderId,
                    customerId = order.CustomerId,
                    orderStatus = OrderStatus.ApprovalPending
                });

                return DataOperationResult.Success();
            }
            catch (Exception ex)
            {
                return new DataOperationResult(DataOperationResultStatus.Failure, message: ex.Message);
            }
        }

        public Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<DataOperationResult> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}