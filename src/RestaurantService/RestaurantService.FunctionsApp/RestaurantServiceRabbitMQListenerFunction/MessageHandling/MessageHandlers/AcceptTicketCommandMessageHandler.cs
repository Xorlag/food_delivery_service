using System.Threading.Tasks;
using FoodDeliveryService.MessageHandling;
using FoodDeliveryService.Messaging;
using RestaurantService.DTO.Messages;

namespace RestaurantService.MessageBrokerListener.RestaurantServiceRabbitMQListenerFunction.MessageHandling.MessageHandlers
{
    internal class AcceptTicketCommandMessageHandler : IMessageHandler
    {
        private readonly Domain.Services.RestaurantService _restaurantService;

        public AcceptTicketCommandMessageHandler(Domain.Services.RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task HandleMessage(MessageEnvelope messageEnvelope)
        {
            var acceptTicketCommand = messageEnvelope.Unwrap<AcceptTicketCommand>();
            await _restaurantService.AcceptTicket(acceptTicketCommand.OrderId);
        }
    }
}
