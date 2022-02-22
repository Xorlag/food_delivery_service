namespace FoodDeliveryService.APIGateway.Configuration
{
    public class RestaurantServiceProxyConfiguration
    {
        public string MessageBrokerConnectionString { get; set; }
        public string MessageBrokerQueueName { get; set; }
    }
}
