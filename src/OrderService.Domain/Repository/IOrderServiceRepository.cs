using FoodDeliveryService.DataAccess.DataOperation;
using OrderService.Domain.Entities;

namespace OrderService.Domain.Repository
{
    public interface IOrderServiceRepository
    {
        public Task<DataOperationResult> CreateOrderAsync(Order order);
        public Task<DataOperationResult> UpdateOrderAsync(Order order);
        public Task<Order> GetOrderByIdAsync(Guid orderId);
    }
}
