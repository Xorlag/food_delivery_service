using FoodDeliveryService.APIGateway.Core.Messaging;

namespace FoodDeliveryService.APIGateway.Services.RestaurantService
{
    public class RestaurantServiceClient
    {
        private readonly IMessageBrokerClientFactory _messageBrockerClientFactory;

        public RestaurantServiceClient(IMessageBrokerClientFactory messageBrockerClientFactory)
        {
            _messageBrockerClientFactory = messageBrockerClientFactory;
        }
    }
}
