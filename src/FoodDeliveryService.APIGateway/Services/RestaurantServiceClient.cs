using FoodDeliveryService.APIGateway.Commands;
using FoodDeliveryService.APIGateway.MessageBrokerClients;

namespace FoodDeliveryService.APIGateway.Services
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
