using FoodDeliveryService.APIGateway.QueueClients.Factory;

namespace FoodDeliveryService.APIGateway.Services
{
    public class OrderServiceClient
    {
        private readonly IMessageBrokerClientFactory _messageBrockerClientFactory;
        private readonly IOrderServiceConfiguration _configuration;

        public OrderServiceClient(IMessageBrokerClientFactory messageBrockerClientFactory, IOrderServiceConfiguration configuration)
        {
            _messageBrockerClientFactory = messageBrockerClientFactory;
            _configuration = configuration;
        }

        public async void CreateOrder()
        {

        }
    }
}
