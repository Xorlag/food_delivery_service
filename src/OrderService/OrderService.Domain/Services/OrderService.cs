using FoodDeliveryService.Services;
using OrderService.Domain.Entities;
using OrderService.Domain.Models.Entities;
using OrderService.Domain.Repository;
using RestaurantService.DTO;
using RestaurantService.Proxy;

namespace OrderService.Domain.Services
{
    public class OrderService
    {
        private readonly RestaurantServiceProxy _restaurantServiceProxy;
        private readonly IOrderServiceRepository _repository;

        public OrderService(RestaurantServiceProxy restaurantServiceProxy, IOrderServiceRepository repository)
        {
            _restaurantServiceProxy = restaurantServiceProxy;
            _repository = repository;
        }

        public async Task<ServiceOperationResult> CreateOrder(OrderDetails orderDetails)
        {
            var dataOperationResult = await _repository.CreateOrderAsync(orderDetails);
            if (dataOperationResult.IsSuccess)
            {
                await _restaurantServiceProxy.CreateTicket(new TicketDetailsDTO
                {
                    OrderId = orderDetails.OrderId,
                    RestaurantId = orderDetails.RestaurantId,
                    TicketLineItems = orderDetails.OrderLineItems.Select(oli => new TicketLineItemDTO
                    {
                        MenuLineItemId = oli.MenuLineItemId,
                        Quantity = oli.Quantity,
                        OrderId = oli.OrderId
                    })
                });
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

        public async Task NoteTicketAccepted(Guid orderId)
        {

        }
    }
}
