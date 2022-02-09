using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryService.Messaging.AzureServiceBus
{
    internal class AzureServiceBusClientFactory : IMessageBrokerClientFactory
    {
        public IMessageBrokerClient CreateClient(MessageBrokerClientOptions options)
        {
            return new AzureServiceBusClient();
        }
    }
}
