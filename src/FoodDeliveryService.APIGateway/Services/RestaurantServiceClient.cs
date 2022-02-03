using FoodDeliveryService.APIGateway.Commands;
using FoodDeliveryService.APIGateway.QueueClients.Factory;

namespace FoodDeliveryService.APIGateway.Services
{
    public class RestaurantServiceClient
    {
        private readonly IMessageBrokerClientFactory _messageBrockerClientFactory;

        public RestaurantServiceClient(IMessageBrokerClientFactory messageBrockerClientFactory)
        {
            _messageBrockerClientFactory = messageBrockerClientFactory;
        }

        public async Task CreateOrder(CreateOrderCommand command)
        {
            var messageBrokerClient = _messageBrockerClientFactory.CreateClient(TargetServices.OrderService);
            await messageBrokerClient.SendMessage(command);
        }
    }
}
