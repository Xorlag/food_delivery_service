using FoodDeliveryService.Messaging;
using OrderService.MessageEnvelopeTypes;
using OrderService.Messages;

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
            var messageEnvelope = new MessageEnvelope(messageId: command.CommandId,
                message: command,
                type: OrderServiceMessageEnvelopeTypes.CreateOrderCommand);
            await messageBrokerClient.SendMessage(messageEnvelope);
        }
    }
}
