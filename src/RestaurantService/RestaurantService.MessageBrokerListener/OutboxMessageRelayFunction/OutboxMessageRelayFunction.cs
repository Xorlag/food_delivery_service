using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FoodDeliveryService.DataAccess.MessageOutbox;
using FoodDeliveryService.Messaging;

namespace RestaurantService.MessageBrokerListener.OutboxMessageRelayFunction
{
    public class OutboxMessageRelayFunction
    {
        private readonly IMessageOutboxRepository _repository;
        private readonly IMessageBrokerClientFactory<OutboxMessageRelayFunction> _messageBrokerClientFactory;

        public OutboxMessageRelayFunction(IMessageOutboxRepository repository)
        {
            _repository = repository;
        }

        [FunctionName(nameof(OutboxMessageRelayFunction))]
        public async Task Run([TimerTrigger("* * * * * *", RunOnStartup = true)] TimerInfo myTimer, ILogger log)
        {
            var unsentMessages = await _repository.GetUnsentMessages();
            var messageBrokerClient = _messageBrokerClientFactory.CreateClient();
            foreach (var unsentMessage in unsentMessages)
            {

            }
        }
    }
}
