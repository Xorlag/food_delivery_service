using FoodDeliveryService.APIGateway.OutboundAdapters.MessageBrokerClients.RabbitMQ;
using FoodDeliveryService.Messaging;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.DataAccess;
using OrderService.Domain.Repository;
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
            ConfigureDependencyInjection(builder.Services);
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IMessageBrokerClientFactory, RabbitMQClientFactory>();
            services.AddSingleton<IOrderServiceRepository, OrderServiceRepository>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var orderServiceDbConnectionString = 
                return new OrderServiceRepository(null);
            });
        }
    }
}
