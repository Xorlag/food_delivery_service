using FoodDeliveryService.APIGateway.Core.Messaging;
using FoodDeliveryService.APIGateway.Core.Models.DomainCommands;

namespace FoodDeliveryService.APIGateway.Services.OrderService
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

        public async Task CreateOrder(CreateOrderCommand command)
        {
            var messageBrokerClient = _messageBrockerClientFactory.CreateClient(new MessageBrokerClientOptions()
            {
                HostUrl = _configuration.OrderServiceMessageBrokerUrl,
                QueueName = _configuration.OrderServiceQueueName
            });
            await messageBrokerClient.SendMessage(command);
        }
    }
}
