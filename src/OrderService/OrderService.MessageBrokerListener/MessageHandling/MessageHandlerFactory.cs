using FoodDeliveryService.MessageHandling.Exceptions;
using OrderService.MessageBrokerListener.MessageHandling;
using OrderService.MessageBrokerListener.MessageHandling.MessageHandlers;
using OrderService.MessageEnvelopeTypes;

namespace RestaurantService.MessageBrokerListener.MessageHandling
{
    public class MessageHandlerFactory
    {
        private readonly OrderService.Domain.Services.OrderService _orderService;

        public MessageHandlerFactory(OrderService.Domain.Services.OrderService orderService)
        {
            _orderService = orderService;
        }

        public IMessageHandler CreateHandler(string messageEnvelopeType)
        {
            switch (messageEnvelopeType)
            {
                case OrderServiceMessageEnvelopeTypes.CreateOrderCommand:
                    {
                        return new CreateOrderCommandMessageHandler();
                    }
                default:
                    {
                        throw new UnsupportedMessageTypeException($"Unsupported Message Type: {messageEnvelopeType}");
                    }
            }
        }
    }
}
