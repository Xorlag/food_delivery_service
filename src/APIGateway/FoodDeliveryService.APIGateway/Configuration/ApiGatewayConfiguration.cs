using OrderService.Proxy;
using RestaurantService.Proxy;

namespace FoodDeliveryService.APIGateway.Configuration
{
    public class ApiGatewayConfiguration
    {
        public OrderServiceProxyConfiguration OrderServiceProxy { get; set; }
        public RestaurantServiceProxyConfiguration RestaurantServiceProxy { get; set; }

    }
}
