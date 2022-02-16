using OrderService.Proxy;
using RestaurantService.Proxy;

namespace FoodDeliveryService.APIGateway.Configuration
{
    public class ApiGatewayConfiguration : IOrderServiceProxyConfiguration, IRestaurantServiceProxyConfiguration
    {
        private readonly IConfiguration _configuration;

        public ApiGatewayConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region IOrderServiceProxyConfiguration

        private const string ORDER_SERVICE_MESSAGE_BROKER_URL_SETTING = "OrderService:MessageBrokerUrl";
        private const string ORDER_SERVICE_QUEUE_NAME = "OrderService:QueueName";
        public string OrderServiceMessageBrokerConnectionString => _configuration.GetValue<string>(ORDER_SERVICE_MESSAGE_BROKER_URL_SETTING);
        public string OrderServiceMessageBrokerQueueName => _configuration.GetValue<string>(ORDER_SERVICE_QUEUE_NAME);

        #endregion

        #region IRestaurantServiceProxyConfiguration

        private const string RESTAURANT_SERVICE_MESSAGE_BROKER_URL_SETTING = "RestaurantService:MessageBrokerUrl";
        private const string RESTAURANT_SERVICE_QUEUE_NAME = "RestaurantService:QueueName";

        public string RestaurantServiceMessageBrokerConnectionString => _configuration.GetValue<string>(RESTAURANT_SERVICE_MESSAGE_BROKER_URL_SETTING);
        public string RestaurantServiceMessageBrokerQueueName => _configuration.GetValue<string>(RESTAURANT_SERVICE_QUEUE_NAME);

        #endregion
    }
}
