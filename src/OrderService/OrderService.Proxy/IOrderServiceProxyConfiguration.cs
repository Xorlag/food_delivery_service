using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Proxy
{
    public interface IOrderServiceProxyConfiguration
    {
        string OrderServiceMessageBrokerConnectionString { get; }
        string OrderServiceMessageBrokerQueueName { get; }
    }
}
