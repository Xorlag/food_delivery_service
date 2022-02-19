using FoodDeliveryService.MessageHandling;
using FoodDeliveryService.MessageHandling.Exceptions;
using Microsoft.Extensions.Logging;
using RestaurantService.DTO.Messages;
using RestaurantService.MessageBrokerListener.MessageHandling.MessageHandlers;

namespace RestaurantService.MessageBrokerListener.MessageHandling
{
    public class MessageHandlerFactory
    {
        private readonly Domain.Services.RestaurantService _restaurantService;
        private readonly ILogger _logger;

        public MessageHandlerFactory(RestaurantService.Domain.Services.RestaurantService restaurantService,
            ILogger logger)
        {
            _restaurantService = restaurantService;
            _logger = logger;
        }

        public IMessageHandler CreateHandler(string messageEnvelopeType)
        {
            switch (messageEnvelopeType)
            {
                case RestaurantServiceMessageEnvelopeTypes.CreateTicketCommand:
                    {
                        return new CreateTicketCommandMessageHandler(_restaurantService, _logger);
                    }
                case RestaurantServiceMessageEnvelopeTypes.AcceptTicketCommand:
                    {
                        return new AcceptTicketCommandMessageHandler(_restaurantService);
                    }
                default:
                    {
                        throw new UnsupportedMessageTypeException($"Unsupported Message Type: {messageEnvelopeType}");
                    }
            }
        }
    }
}
