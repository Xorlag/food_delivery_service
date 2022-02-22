
namespace OrderService.MessageBrokerListener.Configuration
{
    internal class OrderServiceConfiguration
    {
        public string MessageBrokerConnectionString { get; set; }
        public string MessageBrokerQueueName { get; set; }
        public string DatabaseConnectionString { get; set; }
        public RestaurantServiceProxyConfiguration RestaurantServiceProxy { get; set; }
    }
}
