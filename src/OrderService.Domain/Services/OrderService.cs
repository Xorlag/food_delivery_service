using FoodDeliveryService.Services;
using OrderService.Domain.Entities;
using OrderService.Domain.Repository;

namespace OrderService.Domain.Services
{
    internal class OrderService
    {
        private readonly IOrderServiceRepository _repository;

        internal OrderService(IOrderServiceRepository repository)
        {
            _repository = repository;
        }

        internal async Task<ServiceOperationResult> CreateOrder(OrderDetails orderDetails)
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
    }
}
