using RabbitMQ.Client;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDeliveryService.Messaging.RabbitMQ
{
    public static class DepencencyInjectionExtension
    {
        public static void UseRabbitMQClientFactory<TService>(this IServiceCollection services, Func<IServiceProvider, RabbitMQClientOptions> optionsResolver)
        {
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<IMessageBrokerClientFactory<TService>>(sp =>
            {
                var connectionFactory = sp.GetRequiredService<IConnectionFactory>();
                var clientOptions = optionsResolver(sp);
                return new RabbitMQClientFactory<TService>(connectionFactory, clientOptions);
            });
        }
        //public static void UseRabbitMQClientFactory<TService>(this IServiceCollection services, )
    }
}
