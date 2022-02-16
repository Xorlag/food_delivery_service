using RabbitMQ.Client;
using FoodDeliveryService.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDeliveryService.Messaging.RabbitMQ
{
    public static class DepencencyInjectionExtension
    {
        public static void UseRabbitMQClientFactory(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<IMessageBrokerClientFactory, RabbitMQClientFactory>();
        }
    }
}
