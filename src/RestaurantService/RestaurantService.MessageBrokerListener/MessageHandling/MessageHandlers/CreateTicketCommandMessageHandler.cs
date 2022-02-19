using System.Threading.Tasks;
using FoodDeliveryService.MessageHandling;
using FoodDeliveryService.Messaging;
using Microsoft.Extensions.Logging;
using RestaurantService.DTO.Messages;
using RestaurantService.MessageBrokerListener.MessageHandling.Mappers;

namespace RestaurantService.MessageBrokerListener.MessageHandling.MessageHandlers
{
    internal class CreateTicketCommandMessageHandler : IMessageHandler
    {
        private readonly Domain.Services.RestaurantService _restaurantService;
        private readonly ILogger _logger;

        public CreateTicketCommandMessageHandler(RestaurantService.Domain.Services.RestaurantService restaurantService, ILogger logger)
        {
            _restaurantService = restaurantService;
            _logger = logger;
        }

        public async Task HandleMessage(MessageEnvelope messageEnvelope)
        {
            var createTicketCommand = messageEnvelope.Unwrap<CreateTicketCommand>();
            var mapper = new CreateTicketCommandToDetailsMapper();
            var serviceResult = await _restaurantService.CreateTicket(mapper.Map(createTicketCommand));
            if (!serviceResult.IsSuccess)
            {
                _logger.LogError($"Error Occured during Creating Ticket: {serviceResult.Message}");
            }
        }
    }
}
