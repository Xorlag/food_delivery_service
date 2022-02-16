using System;
using System.Threading.Tasks;
using FoodDeliveryService.Messaging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using RestaurantService.Messages;

namespace RestaurantService.MessageBrokerListener
{
    public class RestaurantServiceRabbitMQListenerFunction
    {
        private const string RABBIT_MQ_CONNECTION_STRING_SETTING = "RabbitMq__RestaurantService_ConnectionString";
        private const string RABBIT_MQ_QUEUE_NAME = "RestaurantServiceQueue";

        private RestaurantService.Domain.Services.RestaurantService _restaurantService;

        public RestaurantServiceRabbitMQListenerFunction(RestaurantService.Domain.Services.RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [FunctionName(nameof(RestaurantServiceRabbitMQListenerFunction))]
        public async Task Run([RabbitMQTrigger(queueName:RABBIT_MQ_QUEUE_NAME, ConnectionStringSetting = RABBIT_MQ_CONNECTION_STRING_SETTING)]
        MessageEnvelope messageEnvelope, ILogger log)
        {
            switch (messageEnvelope.Type)
            {
                case RestaurantServiceMessageEnvelopeTypes.CreateTicketCommand:
                    {
                        var createTicketCommand = messageEnvelope.Unwrap<CreateTicketCommand>();
                        break;
                    }
            }
        }
    }
}
