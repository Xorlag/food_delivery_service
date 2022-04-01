using RestaurantService.FunctionsApp.Configuration;

namespace RestaurantService.MessageBrokerListener.Configuration
{
    internal class RestaurantServiceConfiguration
    {
        public string MessageBrokerConnectionString { get; set; }
        public string MessageBrokerQueueName { get; set; }
        public string DatabaseConnectionString { get; set; }
        public OrderServiceProxyConfiguration OrderServiceProxy { get; set; }
    }
}
