using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryService.Messaging.AzureServiceBus
{
    internal class AzureServiceBusClientFactory<T> : IMessageBrokerClientFactory<T>
    {
        public IMessageBrokerClient<T> CreateClient()
        {
            throw new NotImplementedException();
        }
    }
}
