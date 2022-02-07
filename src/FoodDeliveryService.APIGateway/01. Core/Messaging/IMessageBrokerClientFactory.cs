namespace FoodDeliveryService.APIGateway.Core.Messaging
{
    public interface IMessageBrokerClientFactory
    {
        IMessageBrokerClient CreateClient(MessageBrokerClientOptions options);
    }
}
