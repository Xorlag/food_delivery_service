using System.Text.Json;
using FoodDeliveryService.Messaging;
using OrderService.DTO;
using OrderService.MessageEnvelopeTypes;
using OrderService.Messages;

namespace OrderService.Proxy
{
    public class OrderServiceProxy
    {
        private readonly IMessageBrokerClientFactory _messageBrokerClientFactory;
        private readonly IOrderServiceProxyConfiguration _configuration;

        public OrderServiceProxy(IMessageBrokerClientFactory messageBrokerClientFactory,
            IOrderServiceProxyConfiguration configuration)
        {
            _messageBrokerClientFactory = messageBrokerClientFactory;
            _configuration = configuration;
        }

        public async Task CreateOrder(OrderDetailsDTO orderDetails)
        {
            var command = new CreateOrderCommand
            {
                OrderDetails = orderDetails
            };
            var serializedCommand = JsonSerializer.Serialize(command);
            var messageEnvelope = new MessageEnvelope(messageId: orderDetails.OrderId,
                message: serializedCommand,
                type: OrderServiceMessageEnvelopeTypes.CreateOrderCommand);

            var messageBrokerClient = _messageBrokerClientFactory.CreateClient(new MessageBrokerClientOptions
            {
                ConnectionString = _configuration.OrderServiceMessageBrokerConnectionString,
                QueueName = _configuration.OrderServiceMessageBrokerQueueName
            });
            await messageBrokerClient.SendMessageAsync(messageEnvelope);

        }
    }
}