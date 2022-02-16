using System.Threading.Tasks;
using FoodDeliveryService.Messaging;

namespace OrderService.MessageBrokerListener.MessageHandling
{
    public interface IMessageHandler
    {
        Task HandleMessage(MessageEnvelope messageEnvelope);
    }
}
