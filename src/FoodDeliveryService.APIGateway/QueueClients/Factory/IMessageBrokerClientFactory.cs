namespace FoodDeliveryService.APIGateway.QueueClients.Factory
{
    public interface IMessageBrokerClientFactory
    {
        IMessageBrokerClient CreateClient(TargetServices targetService);
    }
}
