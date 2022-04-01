using Microsoft.Extensions.DependencyInjection;
using FoodDeliveryService.DataAccess.MessageOutbox.RepositoryImplementations;

namespace FoodDeliveryService.DataAccess.MessageOutbox
{
    public static class DependencyInjectionExtension
    {
        public static void UseMessageOutboxRepository(this IServiceCollection services)
        {
            services.AddSingleton<IMessageOutboxRepository, MessageOutBoxSqlRepository>();
        }
    }
}
