using RestaurantService.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.MessageBrokerListener.Configuration
{
    public class RestaurantServiceConfiguration : IRestaurantServiceProxyConfiguration
    {
        public string RabbitMqConnectionString { get; set; }
        public string RabbitMqQueueName { get; set; }
        public string RestaurantServiceMessageBrokerConnectionString { get => RabbitMqConnectionString; }
        public string RestaurantServiceMessageBrokerQueueName { get => RabbitMqQueueName; }
    }
}
