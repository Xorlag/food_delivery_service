using FoodDeliveryService.MessageHandling;
using FoodDeliveryService.MessageHandling.Exceptions;
using RestaurantService.MessageBrokerListener.MessageHandling.MessageHandlers;
using RestaurantService.Messages;

namespace RestaurantService.MessageBrokerListener.MessageHandling
{
    public class MessageHandlerFactory
    {
        private readonly Domain.Services.RestaurantService _restaurantService;

        public MessageHandlerFactory(RestaurantService.Domain.Services.RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public IMessageHandler CreateHandler(string messageEnvelopeType)
        {
            switch (messageEnvelopeType)
            {
                case RestaurantServiceMessageEnvelopeTypes.CreateTicketCommand:
                    {
                        return new CreateTicketCommandMessageHandler(_restaurantService);
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
