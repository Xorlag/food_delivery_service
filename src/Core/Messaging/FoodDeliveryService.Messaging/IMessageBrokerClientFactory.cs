namespace FoodDeliveryService.Messaging
{
    public interface IMessageBrokerClientFactory<T>
    {
        IMessageBrokerClient<T> CreateClient();
    }
}
