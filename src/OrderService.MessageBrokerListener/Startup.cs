using FoodDeliveryService.APIGateway.OutboundAdapters.MessageBrokerClients.RabbitMQ;
using FoodDeliveryService.DataAccess.DbConnection;
using FoodDeliveryService.Messaging;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrderService.DataAccess;
using OrderService.Domain.Repository;
using OrderService.MessageBrokerListener.Configuration;
using OrderService.MessageBrokerListener.DataAccess;
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
            services.AddSingleton<IDbConnectionFactory, OrderServiceDbConnectionFactory>();
        }
    }
}
