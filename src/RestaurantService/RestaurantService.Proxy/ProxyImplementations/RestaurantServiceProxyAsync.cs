using System.Text.Json;
using FoodDeliveryService.Messaging;
using RestaurantService.DTO.Entities;
using RestaurantService.DTO.Messages;

namespace RestaurantService.Proxy.ProxyImplementations
{
    public class RestaurantServiceProxyAsync : IRestaurantServiceProxy
    {
        private readonly IMessageBrokerClientFactory<IRestaurantServiceProxy> _messageBrokerClientFactory;

        public RestaurantServiceProxyAsync(IMessageBrokerClientFactory<IRestaurantServiceProxy> messageBrokerClientFactory)
        {
            _messageBrokerClientFactory = messageBrokerClientFactory;
        }

        public async Task CreateTicket(TicketDetailsDTO ticketDetails)
        {
            var createTicketCommand = new CreateTicketCommand
            {
                TicketDetails = ticketDetails
            };
            var serializedCommand = JsonSerializer.Serialize(createTicketCommand);
            var messageEnvelope = new MessageEnvelope(ticketDetails.OrderId,
                serializedCommand,
                RestaurantServiceMessageEnvelopeTypes.CreateTicketCommand);

            var messageBrockerClient = _messageBrokerClientFactory.CreateClient();

            await messageBrockerClient.SendMessageAsync(messageEnvelope);
        }

        public async Task AcceptTicket(Guid orderId)
        {
            var acceptTicketCommand = new AcceptTicketCommand { OrderId = orderId };
            var serializedCommand = JsonSerializer.Serialize(acceptTicketCommand);
            var messageEnvelope = new MessageEnvelope(acceptTicketCommand.OrderId,
                serializedCommand,
                RestaurantServiceMessageEnvelopeTypes.AcceptTicketCommand);

            var messageBrockerClient = _messageBrokerClientFactory.CreateClient();

            await messageBrockerClient.SendMessageAsync(messageEnvelope);
        }

    }
}