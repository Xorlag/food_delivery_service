using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FoodDeliveryService.Messaging;
using OrderService.MessageBrokerListener.Mappers;
using OrderService.MessageEnvelopeTypes;
using OrderService.Messages;


namespace OrderService.MessageBrokerListener
{
    public class OrderServiceRabbitMQListenerFunction
    {
        private const string RABBIT_MQ_CONNECTION_STRING_SETTING = "RabbitMq__OrderService_ConnectionString";
        private const string RABBIT_MQ_QUEUE_NAME = "OrderServiceQueue";

        private OrderService.Domain.Services.OrderService _orderService;

        public OrderServiceRabbitMQListenerFunction(OrderService.Domain.Services.OrderService orderService)
        {
            _orderService = orderService;
        }

        [FunctionName(nameof(OrderServiceRabbitMQListenerFunction))]
        public async Task Run([RabbitMQTrigger(queueName: RABBIT_MQ_QUEUE_NAME, ConnectionStringSetting = RABBIT_MQ_CONNECTION_STRING_SETTING)] MessageEnvelope messageEnvelop,
            ILogger log)
        {
            switch (messageEnvelop.Type)
            {
                case OrderServiceMessageEnvelopeTypes.CreateOrderCommand:
                    var createOrderCommand = messageEnvelop.Unwrap<CreateOrderCommand>();
                    var createOrderCommandToDetailsMapper = new CreateOrderRequestToCommandMapper();
                    var orderDetails = createOrderCommandToDetailsMapper.Map(createOrderCommand);
                    await _orderService.CreateOrder(orderDetails);
                    break;
            }
        }
    }
}
