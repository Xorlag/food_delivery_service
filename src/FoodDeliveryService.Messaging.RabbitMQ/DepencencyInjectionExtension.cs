using RabbitMQ.Client;
using FoodDeliveryService.Messaging;
using Microsoft.Extensions.DependencyInjection;
using FoodDeliveryService.APIGateway.OutboundAdapters.MessageBrokerClients.RabbitMQ;

namespace FoodDeliveryService.Messaging.RabbitMQ
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
