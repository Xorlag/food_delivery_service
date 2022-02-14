using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodDeliveryService.Messaging;
using FoodDeliveryService.DataAccess.Sql.DependencyInjection;
using Microsoft.Extensions.Options;
using RestaurantService.MessageBrokerListener;
using FoodDeliveryService.Messaging.RabbitMQ;
using RestaurantService.MessageBrokerListener.Configuration;
using RestaurantService.Domain.Repositories;
using RestaurantService.DataAccess;

[assembly: FunctionsStartup(typeof(Startup))]
namespace RestaurantService.MessageBrokerListener
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            SetupConfiguration(builder.Services);
            ConfigureDependencyInjection(builder.Services);
        }

        private void SetupConfiguration(IServiceCollection services)
        {
            services.AddOptions<DbConnectionStringsConfiguration>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("DbConnectionStrings").Bind(settings);
                });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<RestaurantService.Domain.Services.RestaurantService>();
            services.AddSingleton<IMessageBrokerClientFactory, RabbitMQClientFactory>();
            services.AddSingleton<IRestaurantServiceRepository, RestaurantServiceRepository>();

            services.RegisterDbConnectionFactory<RestaurantServiceRepository>(serviceProvider =>
            {
                var dbConnectionStringsConfiguration = serviceProvider.GetService<IOptions<DbConnectionStringsConfiguration>>();
                return dbConnectionStringsConfiguration.Value.RestaurantService_DatabaseConnectionString;
            });
        }
    }
}
