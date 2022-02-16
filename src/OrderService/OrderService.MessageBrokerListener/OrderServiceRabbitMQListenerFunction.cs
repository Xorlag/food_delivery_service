using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FoodDeliveryService.Messaging;
using OrderService.MessageBrokerListener.MessageHandling;

namespace OrderService.MessageBrokerListener
{
    public class OrderServiceRabbitMQListenerFunction
    {
        private const string RABBIT_MQ_CONNECTION_STRING_SETTING = "RabbitMq__OrderService_ConnectionString";
        private const string RABBIT_MQ_QUEUE_NAME = "OrderServiceQueue";

        private readonly OrderService.Domain.Services.OrderService _orderService;
        private readonly MessageHandlerFactory _messageHandlerFactory;

        public OrderServiceRabbitMQListenerFunction(OrderService.Domain.Services.OrderService orderService,
            MessageHandlerFactory messageHandlerFactory)
        {
            _orderService = orderService;
            _messageHandlerFactory = messageHandlerFactory;
        }

        [FunctionName(nameof(OrderServiceRabbitMQListenerFunction))]
        public async Task Run([RabbitMQTrigger(queueName: RABBIT_MQ_QUEUE_NAME, ConnectionStringSetting = RABBIT_MQ_CONNECTION_STRING_SETTING)] MessageEnvelope messageEnvelope,
            ILogger log)
        {
            var messageHandler = _messageHandlerFactory.CreateHandler(messageEnvelope.Type);
            await messageHandler.HandleMessage(messageEnvelope);
        }
    }
}
