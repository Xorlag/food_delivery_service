using FoodDeliveryService.DataAccess.DataOperation;
using FoodDeliveryService.Messaging;

namespace FoodDeliveryService.DataAccess.MessageOutbox
{
    public interface IMessageOutboxRepository
    {
        public Task<IEnumerable<MessageEnvelope>> GetUnsentMessages();

        public Task<DataOperationResult> NotifyMessageSent(Guid messageId);

        public Task<DataOperationResult> SaveOutboxMessage(MessageEnvelope messageEnvelope);
    }
}