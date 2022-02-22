using Microsoft.Extensions.DependencyInjection;

namespace FoodDeliveryService.Messaging.AzureServiceBus
{
    public static class DepencencyInjectionExtension
    {
        public static void RegisterAzureServiceBusDependencies<TService>(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBrokerClientFactory<TService>, AzureServiceBusClientFactory<TService>>();
        }
    }
}
