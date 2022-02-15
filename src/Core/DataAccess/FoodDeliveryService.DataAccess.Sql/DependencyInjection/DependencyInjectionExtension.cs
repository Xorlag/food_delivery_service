using Microsoft.Extensions.DependencyInjection;
using FoodDeliveryService.DataAccess.Sql.DbConnection;

namespace FoodDeliveryService.DataAccess.Sql.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterDbConnectionFactory<TTargetRepo>(this IServiceCollection services, Func<IServiceProvider, string> connectionStringResolver)
        {
            services.AddSingleton<IDbConnectionFactory<TTargetRepo>>(serviceProvider =>
            {
                var connectionString = connectionStringResolver(serviceProvider);
                var dbConnectionFactoryInstance = new DbConnectionFactory<TTargetRepo>(connectionString);
                return dbConnectionFactoryInstance;
            });
        }
    }
}
