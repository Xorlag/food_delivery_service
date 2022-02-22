using System;
using FoodDeliveryService.Messaging;
using FoodDeliveryService.Messaging.MessageOutboxClient;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace RestaurantService.MessageBrokerListener
{
    public class OutboxMessageRelayFunction
    {
        private readonly IMessageOutboxRepository _repository;
        //private readonly IMessageBrokerClientFactory _messageBrokerClientFactory;

        public OutboxMessageRelayFunction(IMessageOutboxRepository repository)
        {
            _repository = repository;
        }

        [FunctionName(nameof(OutboxMessageRelayFunction))]
        public void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var unsentMessages = _repository.GetUnsentMessages();
            //var messageBrokerClient = _messageBrokerClientFactory.CreateClient();
        }
    }
}
