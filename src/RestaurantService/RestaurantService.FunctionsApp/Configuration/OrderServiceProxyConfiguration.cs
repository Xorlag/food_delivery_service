namespace RestaurantService.FunctionsApp.Configuration
{
    internal class OrderServiceProxyConfiguration
    {
        public string MessageBrokerConnectionString { get; set; }
        public string MessageBrokerQueueName { get; set; }
    }
}