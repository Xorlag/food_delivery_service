using FoodDeliveryService.DataAccess.DataOperation;
using OrderService.Domain.Entities;
using OrderService.Domain.Repository;

namespace OrderService.DataAccess
{
    public class OrderServiceRepository : IOrderServiceRepository
    {
        public async Task<DataOperationResult> CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
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