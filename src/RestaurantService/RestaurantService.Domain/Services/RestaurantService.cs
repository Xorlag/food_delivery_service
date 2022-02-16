using FoodDeliveryService.Services;
using OrderService.Proxy;
using RestaurantService.Domain.Entities;
using RestaurantService.Domain.Repositories;

namespace RestaurantService.Domain.Services
{
    public class RestaurantService
    {
        private readonly IRestaurantServiceRepository _restaurantServiceRepository;
        private readonly OrderServiceProxy _orderServiceProxy;

        public RestaurantService(IRestaurantServiceRepository restaurantServiceRepository,
            OrderServiceProxy orderServiceProxy)
        {
            _restaurantServiceRepository = restaurantServiceRepository;
            _orderServiceProxy = orderServiceProxy;
        }
        public async Task<ServiceOperationResult> CreateTicket(TicketDetails ticketDetails)
        {
            var dbOperationResult = await _restaurantServiceRepository.CreateTicket(ticketDetails);
            var serviceResult = dbOperationResult.IsSuccess ? new ServiceOperationResult(ServiceOperationResultStatus.Success)
                                                            : new ServiceOperationResult(ServiceOperationResultStatus.Failure, dbOperationResult.Message);
            return serviceResult;
        }

        public async Task<ServiceOperationResult> AcceptTicket(Guid orderId)
        {
            var ticket = await _restaurantServiceRepository.GetTicketById(orderId);
            if (ticket == null)
            {
                return new ServiceOperationResult(ServiceOperationResultStatus.Failure, "Ticket not found");
            }
            await _restaurantServiceRepository.UpdateTicketStatus(orderId, TicketStatus.InProgress);
            await _orderServiceProxy.NotifyOrderAccepted(orderId);
            return new ServiceOperationResult(ServiceOperationResultStatus.Success);
        }
    }
}
