﻿namespace FoodDeliveryService.APIGateway.Configuration
{
    public class OrderServiceProxyConfiguration
    {
        public string MessageBrokerConnectionString { get; set; }
        public string MessageBrokerQueueName { get; set; }
    }
}