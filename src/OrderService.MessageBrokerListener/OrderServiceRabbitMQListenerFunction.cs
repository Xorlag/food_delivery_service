using System;
using FoodDeliveryService.Messaging;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace OrderService.MessageBrokerListener
{
    public class OrderServiceRabbitMQListenerFunction
    {
        private const string RABBIT_MQ_CONNECTION_STRING_SETTING = "OrderService__RabbitMqConnectionString";
        private const string RABBIT_MQ_QUEUE_NAME = "OrderServiceQueue";
        [FunctionName(nameof(OrderServiceRabbitMQListenerFunction))]
        public void Run([RabbitMQTrigger(queueName: RABBIT_MQ_QUEUE_NAME, ConnectionStringSetting = RABBIT_MQ_CONNECTION_STRING_SETTING)]MessageEnvelope myQueueItem, ILogger log)
        {
            
        }
    }
}
