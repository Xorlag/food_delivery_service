using FoodDeliveryService.APIGateway.Services;

namespace FoodDeliveryService.APIGateway.Configuration
{
    public class ApiGatewayConfiguration : IOrderServiceConfiguration
    {
        private const string ORDER_SERVICE_MESSAGE_BROKER_URL_SETTING = "OrderService:MessageBrokerUrl";
        private const string ORDER_SERVICE_QUEUE_NAME = "OrderService:QueueName";

        private readonly IConfiguration _configuration;

        public ApiGatewayConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string OrderServiceMessageBrokerUrl { get => _configuration.GetValue<string>(ORDER_SERVICE_MESSAGE_BROKER_URL_SETTING); }
        public string OrderServiceQueueName { get => _configuration.GetValue<string>(ORDER_SERVICE_QUEUE_NAME); }
    }
}
