namespace OrderService.FunctionsApp.Configuration
{
    internal class RestaurantServiceProxyConfiguration
    {
        public string MessageBrokerConnectionString { get; set; }
        public string MessageBrokerQueueName { get; set; }
    }
}