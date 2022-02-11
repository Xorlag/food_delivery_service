using FoodDeliveryService.Services;
using OrderService.Domain.Entities;
using OrderService.Domain.Models.Entities;
using OrderService.Domain.Repository;

namespace OrderService.Domain.Services
{
    public class OrderService
    {
        private readonly IOrderServiceRepository _repository;

        public OrderService(IOrderServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceOperationResult> CreateOrder(OrderDetails orderDetails)
        {
            var dataOperationResult = await _repository.CreateOrderAsync(orderDetails);
            if (dataOperationResult.IsSuccess)
            {
                return new ServiceOperationResult(ServiceOperationResultStatus.Success);
            }
            else
            {
                return new ServiceOperationResult(ServiceOperationResultStatus.Failure, dataOperationResult.Message);
            }
        }

        public async Task<ServiceOperationResult<Order>> GetOrderById(Guid OrderId)
        {
            try
            {
                var resultOrder = await _repository.GetOrderByIdAsync(OrderId);
                return new ServiceOperationResult<Order>(resultOrder);
            }
            catch (Exception ex)
            {
                return new ServiceOperationResult<Order>(ServiceOperationResultStatus.Failure, ex.Message);
            }
        }
    }
}
