using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FoodDeliveryService.Messaging;
using RestaurantService.Messages;
using RestaurantService.MessageBrokerListener.MessageHandling;

namespace RestaurantService.MessageBrokerListener
{
    public class RestaurantServiceRabbitMQListenerFunction
    {
        private const string RABBIT_MQ_CONNECTION_STRING_SETTING = "RabbitMq__RestaurantService_ConnectionString";
        private const string RABBIT_MQ_QUEUE_NAME = "RestaurantServiceQueue";

        private readonly RestaurantService.Domain.Services.RestaurantService _restaurantService;
        private readonly MessageHandlerFactory _messageHandlerFactory;

        public RestaurantServiceRabbitMQListenerFunction(RestaurantService.Domain.Services.RestaurantService restaurantService,
            MessageHandlerFactory messageHandlerFactory)
        {
            _restaurantService = restaurantService;
            _messageHandlerFactory = messageHandlerFactory;
        }

        [FunctionName(nameof(RestaurantServiceRabbitMQListenerFunction))]
        public async Task Run([RabbitMQTrigger(queueName:RABBIT_MQ_QUEUE_NAME, ConnectionStringSetting = RABBIT_MQ_CONNECTION_STRING_SETTING)]
        MessageEnvelope messageEnvelope, ILogger log)
        {
            var messageHandler = _messageHandlerFactory.CreateHandler(messageEnvelope.Type);
            await messageHandler.HandleMessage(messageEnvelope);
        }
    }
}
