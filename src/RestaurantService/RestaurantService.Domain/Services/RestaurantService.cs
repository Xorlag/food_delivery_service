using FoodDeliveryService.Services;
using RestaurantService.Domain.Entities;
using RestaurantService.Domain.Repositories;

namespace RestaurantService.Domain.Services
{
    public class RestaurantService
    {
        private readonly IRestaurantServiceRepository _restaurantServiceRepository;

        public RestaurantService(IRestaurantServiceRepository restaurantServiceRepository)
        {
            _restaurantServiceRepository = restaurantServiceRepository;
        }
        public async Task<ServiceOperationResult> CreateTicket(TicketDetails ticketDetails)
        {
            var dbOperationResult = await _restaurantServiceRepository.CreateTicket(ticketDetails);
            var serviceResult = dbOperationResult.IsSuccess ? new ServiceOperationResult(ServiceOperationResultStatus.Success)
                                                            : new ServiceOperationResult(ServiceOperationResultStatus.Failure, dbOperationResult.Message);
            return serviceResult;
        }
    }
}
