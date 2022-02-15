using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodDeliveryService.Messaging;
using OrderService.DataAccess;
using OrderService.Domain.Repository;
using OrderService.MessageBrokerListener.Configuration;
using FoodDeliveryService.DataAccess.Sql.DependencyInjection;
using Microsoft.Extensions.Options;
using FoodDeliveryService.Messaging.RabbitMQ;

[assembly: FunctionsStartup(typeof(OrderService.MessageBrokerListener.Startup))]
namespace OrderService.MessageBrokerListener
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
            services.AddSingleton<OrderService.Domain.Services.OrderService>();
            services.AddSingleton<IMessageBrokerClientFactory, RabbitMQClientFactory>();
            services.AddSingleton<IOrderServiceRepository, OrderServiceRepository>();

            services.RegisterDbConnectionFactory<OrderServiceRepository>(serviceProvider =>
            {
                var dbConnectionStringsConfiguration = serviceProvider.GetService<IOptions<DbConnectionStringsConfiguration>>();
                return dbConnectionStringsConfiguration.Value.OrderService_DatabaseConnectionString;
            });
        }
    }
}
