using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FoodDeliveryService.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using OrderService.Domain.Models.Entities;
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
                    var dtoOrderDetails = createOrderCommand.OrderDetails;
                    await _orderService.CreateOrder(new Domain.Entities.OrderDetails
                    {
                        OrderId = dtoOrderDetails.OrderId,
                        CustomerId = dtoOrderDetails.CustomerId,
                        OrderLineItems = dtoOrderDetails.OrderLineItems.Select(dtoItem=> new OrderLineItem
                        {
                            MenuLineItemId = dtoItem.MenuLineItemId,
                            OrderId = dtoItem.OrderId,
                            Quantity = dtoItem.Quantity
                        }),
                        RestaurantId = dtoOrderDetails.RestaurantId,
                        DeliveryInfo = new DeliveryInfo
                        {
                            OrderId = dtoOrderDetails.DeliveryInfo.OrderId,
                            ApartmentsNumber = dtoOrderDetails.DeliveryInfo.ApartmentsNumber,
                            BuildingNumber = dtoOrderDetails.DeliveryInfo.BuildingNumber,
                            City = dtoOrderDetails.DeliveryInfo.City,
                            Street = dtoOrderDetails.DeliveryInfo.Street
                        },
                    });
                    break;
            }
        }
    }
}
