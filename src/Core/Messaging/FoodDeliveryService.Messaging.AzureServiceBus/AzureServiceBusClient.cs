namespace FoodDeliveryService.Messaging.AzureServiceBus
{
    public class AzureServiceBusClient : IMessageBrokerClient
    {
        public Task SendMessageAsync(MessageEnvelope message)
        {
            throw new NotImplementedException();
        }
    }
}