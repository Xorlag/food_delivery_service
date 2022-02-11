using Microsoft.Extensions.DependencyInjection;
using FoodDeliveryService.Messaging.AzureServiceBus;

namespace FoodDeliveryService.Messaging.RabbitMQ
{
    public static class DepencencyInjectionExtension
    {
        public static void RegisterAzureServiceBusDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBrokerClientFactory, AzureServiceBusClientFactory>();
        }
    }
}
