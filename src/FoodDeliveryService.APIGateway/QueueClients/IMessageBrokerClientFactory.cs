namespace FoodDeliveryService.APIGateway.QueueClients
{
    public interface IMessageBrokerClientFactory
    {
        IMessageBrokerClient CreateClient(MessageBrokerClientOptions options);
    }
}
