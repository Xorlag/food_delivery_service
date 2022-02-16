using FoodDeliveryService.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.MessageBrokerListener.MessageHandling
{
    public interface IMessageHandler
    {
        Task HandleMessage(MessageEnvelope messageEnvelope);
    }
}
