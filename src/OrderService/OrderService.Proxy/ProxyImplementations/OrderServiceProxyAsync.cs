using FoodDeliveryService.Messaging;
using OrderService.DTO.Entities;
using OrderService.DTO.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderService.Proxy.ProxyImplementations
{
    public class OrderServiceProxyAsync : IOrderServiceProxy
    {
        private readonly IMessageBrokerClientFactory<IOrderServiceProxy> _messageBrokerClientFactory;

        public OrderServiceProxyAsync(IMessageBrokerClientFactory<IOrderServiceProxy> messageBrokerClientFactory)
        {
            _messageBrokerClientFactory = messageBrokerClientFactory;
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

            var messageBrokerClient = _messageBrokerClientFactory.CreateClient();
            await messageBrokerClient.SendMessageAsync(messageEnvelope);
        }
    }
}
