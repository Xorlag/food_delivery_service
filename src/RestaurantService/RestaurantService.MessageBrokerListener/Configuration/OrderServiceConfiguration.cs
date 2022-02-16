using OrderService.Proxy;

namespace RestaurantService.MessageBrokerListener.Configuration
{
    public class OrderServiceConfiguration : IOrderServiceProxyConfiguration
    {
        public string RabbitMqConnectionString { get; set; }
        public string RabbitMqQueueName { get; set; }

        public string OrderServiceMessageBrokerConnectionString => RabbitMqConnectionString;

        public string OrderServiceMessageBrokerQueueName => RabbitMqQueueName;
    }
}
