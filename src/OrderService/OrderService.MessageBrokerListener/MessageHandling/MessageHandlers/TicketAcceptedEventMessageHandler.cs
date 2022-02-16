using FoodDeliveryService.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.MessageBrokerListener.MessageHandling.MessageHandlers
{
    internal class TicketAcceptedEventMessageHandler : IMessageHandler
    {
        public Task HandleMessage(MessageEnvelope messageEnvelope)
        {
            throw new NotImplementedException();
        }
    }
}
