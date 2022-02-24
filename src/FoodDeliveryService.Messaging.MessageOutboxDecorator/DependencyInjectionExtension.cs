using Microsoft.Extensions.DependencyInjection;
using FoodDeliveryService.Messaging.MessageOutboxDecorator;
using FoodDeliveryService.DataAccess.MessageOutbox;

namespace FoodDeliveryService.Messaging.MessageOutboxClient
{
    public static class DependencyInjectionExtension
    {
        public static void UseMessageOutboxClient<TService>(this IServiceCollection services)
        {
            services.UseMessageOutboxRepository();
            services.AddSingleton<IMessageBrokerClient<TService>, OutboxMessageBrokerClient<TService>>();
        }
    }
}
