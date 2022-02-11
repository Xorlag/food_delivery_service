using FoodDeliveryService.APIGateway.OutboundAdapters.MessageBrokerClients.RabbitMQ;
using FoodDeliveryService.Messaging;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrderService.DataAccess;
using OrderService.Domain.Repository;
using OrderService.MessageBrokerListener.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddOptions<OrderServiceConfiguration>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("OrderService").Bind(settings);
                });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<OrderService.Domain.Services.OrderService>();
            services.AddSingleton<IMessageBrokerClientFactory, RabbitMQClientFactory>();
            services.AddSingleton<IOrderServiceRepository, OrderServiceRepository>(sp =>
            {
                var configuration = sp.GetRequiredService<IOptions<OrderServiceConfiguration>>();
                return new OrderServiceRepository(configuration.Value.DatabaseConnectionString);
            });
        }
    }
}
