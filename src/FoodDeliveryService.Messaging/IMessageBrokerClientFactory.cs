namespace FoodDeliveryService.Messaging
{
    public interface IMessageBrokerClientFactory
    {
        IMessageBrokerClient CreateClient(MessageBrokerClientOptions options);
    }
}
