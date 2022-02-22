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
using RestaurantService.MessageBrokerListener.MessageHandling;
using OrderService.Proxy;
using OrderService.Proxy.ProxyImplementations;

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
            services.AddOptions<RestaurantServiceConfiguration>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("RestaurantService").Bind(settings);
                });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<RestaurantService.Domain.Services.RestaurantService>();
            services.AddSingleton<IOrderServiceProxy, OrderServiceProxyAsync>();
            services.AddSingleton<IRestaurantServiceRepository, RestaurantServiceRepository>();
            services.AddSingleton<MessageHandlerFactory>();

            services.UseRabbitMQClientFactory<IOrderServiceProxy>(sp =>
            {
                var configuration = sp.GetService<IOptions<RestaurantServiceConfiguration>>().Value.OrderServiceProxy;
                return new RabbitMQClientOptions
                {
                    ConnectionString = configuration.MessageBrokerConnectionString,
                    QueueName = configuration.MessageBrokerQueueName
                };
            });

            services.RegisterDbConnectionFactory<RestaurantServiceRepository>(serviceProvider =>
            {
                var dbConnectionStringsConfiguration = serviceProvider.GetRequiredService<IOptions<RestaurantServiceConfiguration>>().Value;
                return dbConnectionStringsConfiguration.DatabaseConnectionString;
            });
        }
    }
}
