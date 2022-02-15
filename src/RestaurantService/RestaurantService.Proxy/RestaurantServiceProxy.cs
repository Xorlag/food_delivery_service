using System.Text.Json;
using FoodDeliveryService.Messaging;
using RestaurantService.DTO;
using RestaurantService.Messages;

namespace RestaurantService.Proxy
{
    public class RestaurantServiceProxy
    {
        private readonly IMessageBrokerClientFactory _messageBrokerClientFactory;
        private readonly IRestaurantServiceProxyConfiguration _configuration;

        public RestaurantServiceProxy(IMessageBrokerClientFactory messageBrokerClientFactory,
            IRestaurantServiceProxyConfiguration configuration)
        {
            _messageBrokerClientFactory = messageBrokerClientFactory;
            _configuration = configuration;
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

            var messageBrockerClient = _messageBrokerClientFactory.CreateClient(new MessageBrokerClientOptions
            {
                ConnectionString = _configuration.RestaurantServiceMessageBrokerConnectionString,
                QueueName = _configuration.RestaurantServiceMessageBrokerQueueName
            });

            await messageBrockerClient.SendMessageAsync(messageEnvelope);
        }

    }
}