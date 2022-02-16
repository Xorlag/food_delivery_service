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
            await SendMessageAsync(orderDetails.OrderId, command, OrderServiceMessageEnvelopeTypes.CreateOrderCommand);
        }

        public async Task NotifyOrderAccepted(Guid orderId)
        {
            var command = new TicketAcceptedEvent
            {
                OrderId = orderId
            };
            await SendMessageAsync(orderId, command, OrderServiceMessageEnvelopeTypes.TicketAcceptedEvent);
        }

        private async Task SendMessageAsync(Guid messageId, object command, string messageEnvelopType)
        {
            var serializedCommand = JsonSerializer.Serialize(command);
            var messageEnvelope = new MessageEnvelope(messageId: messageId,
                message: serializedCommand,
                type: messageEnvelopType);

            var messageBrokerClient = _messageBrokerClientFactory.CreateClient(new MessageBrokerClientOptions
            {
                ConnectionString = _configuration.OrderServiceMessageBrokerConnectionString,
                QueueName = _configuration.OrderServiceMessageBrokerQueueName
            });
            await messageBrokerClient.SendMessageAsync(messageEnvelope);
        }
    }
}