using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Proxy
{
    public interface IRestaurantServiceProxyConfiguration
    {
        public string RestaurantServiceMessageBrokerConnectionString { get; }
        public string RestaurantServiceMessageBrokerQueueName { get; }
    }
}
