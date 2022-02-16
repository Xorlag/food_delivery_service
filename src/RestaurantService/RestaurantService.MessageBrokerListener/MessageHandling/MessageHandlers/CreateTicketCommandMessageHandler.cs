using System.Threading.Tasks;
using FoodDeliveryService.Messaging;
using RestaurantService.MessageBrokerListener.MessageHandling.Mappers;
using RestaurantService.Messages;

namespace RestaurantService.MessageBrokerListener.MessageHandling.MessageHandlers
{
    internal class CreateTicketCommandMessageHandler : IMessageHandler
    {
        private readonly Domain.Services.RestaurantService _restaurantService;

        public CreateTicketCommandMessageHandler(RestaurantService.Domain.Services.RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task HandleMessage(MessageEnvelope messageEnvelope)
        {
            var createTicketCommand = messageEnvelope.Unwrap<CreateTicketCommand>();
            var mapper = new CreateTicketCommandToDetailsMapper();
            await _restaurantService.CreateTicket(mapper.Map(createTicketCommand));
        }
    }
}
