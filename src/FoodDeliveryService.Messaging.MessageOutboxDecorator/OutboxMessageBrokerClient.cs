using FoodDeliveryService.DataAccess.MessageOutbox;

namespace FoodDeliveryService.Messaging.MessageOutboxDecorator
{
    internal class OutboxMessageBrokerClient<TService> : IMessageBrokerClient<TService>
    {
        private readonly IMessageOutboxRepository _repository;

        public OutboxMessageBrokerClient(IMessageOutboxRepository repository)
        {
            _repository = repository;
        }

        public async Task SendMessageAsync(MessageEnvelope message)
        {
            await _repository.SaveOutboxMessage(message);
        }
    }
}