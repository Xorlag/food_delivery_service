namespace FoodDeliveryService.Messaging.AzureServiceBus
{
    public class AzureServiceBusClient<T> : IMessageBrokerClient<T>
    {
        public Task SendMessageAsync(MessageEnvelope message)
        {
            throw new NotImplementedException();
        }
    }
}