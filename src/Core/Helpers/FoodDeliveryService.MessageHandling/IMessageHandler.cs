using System.Threading.Tasks;
using FoodDeliveryService.Messaging;

namespace FoodDeliveryService.MessageHandling
{
    public interface IMessageHandler
    {
        Task HandleMessage(MessageEnvelope messageEnvelope);
    }
}
