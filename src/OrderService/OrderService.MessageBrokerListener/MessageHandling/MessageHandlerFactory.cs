using FoodDeliveryService.MessageHandling;
using FoodDeliveryService.MessageHandling.Exceptions;
using OrderService.DTO.Messages;
using OrderService.FunctionsApp.MessageHandling.MessageHandlers;
using OrderService.MessageBrokerListener.MessageHandling.MessageHandlers;

namespace OrderService.FunctionsApp.MessageHandling
{
    public class MessageHandlerFactory
    {
        private readonly Domain.Services.OrderService _orderService;

        public MessageHandlerFactory(Domain.Services.OrderService orderService)
        {
            _orderService = orderService;
        }

        public IMessageHandler CreateHandler(string messageEnvelopeType)
        {
            switch (messageEnvelopeType)
            {
                case OrderServiceMessageEnvelopeTypes.CreateOrderCommand:
                    {
                        return new CreateOrderCommandMessageHandler(_orderService);
                    }
                case OrderServiceMessageEnvelopeTypes.TicketAcceptedEvent:
                    {
                        return new TicketAcceptedEventMessageHandler(_orderService);
                    }
                default:
                    {
                        throw new UnsupportedMessageTypeException($"Unsupported Message Type: {messageEnvelopeType}");
                    }
            }
        }
    }
}
