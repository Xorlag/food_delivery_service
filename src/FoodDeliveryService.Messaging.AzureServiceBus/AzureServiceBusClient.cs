namespace FoodDeliveryService.Messaging.AzureServiceBus
{
    public class AzureServiceBusClient : IMessageBrokerClient
    {
        public Task SendMessage(MessageEnvelope message)
        {
            throw new NotImplementedException();
        }
    }
}