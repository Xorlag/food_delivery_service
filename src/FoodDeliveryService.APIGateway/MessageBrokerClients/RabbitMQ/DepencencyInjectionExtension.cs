using FoodDeliveryService.APIGateway.MessageBrokerClients;
using RabbitMQ.Client;

namespace FoodDeliveryService.APIGateway.MessageBrokerClients.RabbitMQ
{
    public static class DepencencyInjectionExtension
    {
        public static void RegisterRabbitMQDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<IMessageBrokerClientFactory, RabbitMQClientFactory>();
        }
    }
}
