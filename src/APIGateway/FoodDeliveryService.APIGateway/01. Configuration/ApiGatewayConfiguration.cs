using OrderService.Proxy;

namespace FoodDeliveryService.APIGateway.Configuration
{
    public class ApiGatewayConfiguration : IOrderServiceProxyConfiguration
    {
        private const string ORDER_SERVICE_MESSAGE_BROKER_URL_SETTING = "OrderService:MessageBrokerUrl";
        private const string ORDER_SERVICE_QUEUE_NAME = "OrderService:QueueName";

        private readonly IConfiguration _configuration;

        public ApiGatewayConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string OrderServiceMessageBrokerConnectionString { get => _configuration.GetValue<string>(ORDER_SERVICE_MESSAGE_BROKER_URL_SETTING); }
        public string OrderServiceMessageBrokerQueueName { get => _configuration.GetValue<string>(ORDER_SERVICE_QUEUE_NAME); }
    }
}
