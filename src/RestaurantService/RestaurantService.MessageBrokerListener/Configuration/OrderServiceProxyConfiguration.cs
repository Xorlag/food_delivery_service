﻿namespace RestaurantService.MessageBrokerListener.Configuration
{
    internal class OrderServiceProxyConfiguration
    {
        public string MessageBrokerConnectionString { get; set; }
        public string MessageBrokerQueueName { get; set; }
    }
}