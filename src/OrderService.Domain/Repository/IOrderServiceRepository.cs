using FoodDeliveryService.DataAccess.DataOperation;
using OrderService.Domain.Entities;
using OrderService.Domain.Models.Entities;

namespace OrderService.Domain.Repository
{
    public interface IOrderServiceRepository
    {
        public Task<DataOperationResult> CreateOrderAsync(OrderDetails order);
        public Task<DataOperationResult> UpdateOrderAsync(Order order);
        public Task<Order> GetOrderByIdAsync(Guid orderId);
    }
}
