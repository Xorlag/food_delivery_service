using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using FoodDeliveryService.Messaging;
using OrderService.DataAccess;
using OrderService.Domain.Repository;
using FoodDeliveryService.DataAccess.Sql.DependencyInjection;
using FoodDeliveryService.Messaging.RabbitMQ;
using RestaurantService.Proxy;
using RestaurantService.Proxy.ProxyImplementations;
using OrderService.FunctionsApp;
using OrderService.FunctionsApp.MessageHandling;
using OrderService.FunctionsApp.Configuration;

[assembly: FunctionsStartup(typeof(Startup))]
namespace OrderService.FunctionsApp
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
            services.AddOptions<OrderServiceConfiguration>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("OrderService").Bind(settings);
                });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<Domain.Services.OrderService>();
            services.AddSingleton<IRestaurantServiceProxy, RestaurantServiceProxyAsync>();
            services.AddSingleton<IOrderServiceRepository, OrderServiceRepository>();
            services.AddSingleton<MessageHandlerFactory>();

            services.UseRabbitMQClientFactory<IRestaurantServiceProxy>(sp =>
            {
                var configuration = sp.GetRequiredService<IOptions<OrderServiceConfiguration>>()
                .Value
                .RestaurantServiceProxy;

                return new RabbitMQClientOptions
                {
                    ConnectionString = configuration.MessageBrokerConnectionString,
                    QueueName = configuration.MessageBrokerQueueName
                };
            });

            services.RegisterDbConnectionFactory<OrderServiceRepository>(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IOptions<OrderServiceConfiguration>>().Value;
                return configuration.DatabaseConnectionString;
            });
        }
    }
}
