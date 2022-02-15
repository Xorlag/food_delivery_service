using System;
using System.Threading.Tasks;
using FoodDeliveryService.Messaging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace RestaurantService.MessageBrokerListener
{
    public class RestaurantServiceRabbitMQListenerFunction
    {
        private const string RABBIT_MQ_CONNECTION_STRING_SETTING = "RestaurantService__RabbitMqConnectionString";
        private const string RABBIT_MQ_QUEUE_NAME = "RestaurantServiceQueue";
        private RestaurantService.Domain.Services.RestaurantService _restaurantService;

        [FunctionName(nameof(RestaurantServiceRabbitMQListenerFunction))]
        public async Task Run([RabbitMQTrigger(queueName:RABBIT_MQ_QUEUE_NAME, ConnectionStringSetting = RABBIT_MQ_CONNECTION_STRING_SETTING)]MessageEnvelope myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
