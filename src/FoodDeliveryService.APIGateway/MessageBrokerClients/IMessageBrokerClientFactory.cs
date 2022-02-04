namespace FoodDeliveryService.APIGateway.MessageBrokerClients
{
    public interface IMessageBrokerClientFactory
    {
        IMessageBrokerClient CreateClient(MessageBrokerClientOptions options);
    }
}
