using System;
using System.Text.Json;
using System.Threading.Tasks;
using FoodDeliveryService.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using OrderService.MessageEnvelopeTypes;
using OrderService.Messages;


namespace OrderService.MessageBrokerListener
{
    public class OrderServiceRabbitMQListenerFunction
    {
        private const string RABBIT_MQ_CONNECTION_STRING_SETTING = "OrderService__RabbitMqConnectionString";
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
                    await _orderService.CreateOrder(new Domain.Entities.OrderDetails
                    {
                        OrderId = createOrderCommand.OrderId,
                        CustomerId = createOrderCommand.CustomerId,
                        OrderLineItems = createOrderCommand.OrderLineItems,
                        RestaurantId = createOrderCommand.RestaurantId,
                    });
                    break;
            }
        }
    }
}
