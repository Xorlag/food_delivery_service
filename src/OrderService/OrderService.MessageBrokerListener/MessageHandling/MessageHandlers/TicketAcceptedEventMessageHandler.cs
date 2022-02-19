using System.Threading.Tasks;
using FoodDeliveryService.MessageHandling;
using FoodDeliveryService.Messaging;
using OrderService.DTO.Messages;

namespace OrderService.MessageBrokerListener.MessageHandling.MessageHandlers
{
    internal class TicketAcceptedEventMessageHandler : IMessageHandler
    {
        private readonly Domain.Services.OrderService _orderService;

        public TicketAcceptedEventMessageHandler(OrderService.Domain.Services.OrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task HandleMessage(MessageEnvelope messageEnvelope)
        {
            var ticketAcceptedEvent = messageEnvelope.Unwrap<TicketAcceptedEvent>();
            await _orderService.NoteTicketAccepted(ticketAcceptedEvent.OrderId);
        }
    }
}
