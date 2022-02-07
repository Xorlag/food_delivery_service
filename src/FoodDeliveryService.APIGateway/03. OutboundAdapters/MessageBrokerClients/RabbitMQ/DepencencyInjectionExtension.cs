using RabbitMQ.Client;
using FoodDeliveryService.APIGateway.Core.Messaging;

namespace FoodDeliveryService.APIGateway.OutboundAdapters.MessageBrokerClients.RabbitMQ
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
