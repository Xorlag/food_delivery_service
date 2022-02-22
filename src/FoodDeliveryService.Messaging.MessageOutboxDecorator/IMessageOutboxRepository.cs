using FoodDeliveryService.DataAccess.DataOperation;
using FoodDeliveryService.Messaging.MessageOutboxClient.Entities;

namespace FoodDeliveryService.Messaging.MessageOutboxClient
{
    public interface IMessageOutboxRepository
    {
        Task<DataOperationResult> SaveOutboxMessage(MessageEnvelope messageEnvelope);
        Task<DataOperationResult> NotifyMessageSent(Guid messageId);
        Task<IEnumerable<MessageEnvelope>> GetUnsentMessages();
    }
}
