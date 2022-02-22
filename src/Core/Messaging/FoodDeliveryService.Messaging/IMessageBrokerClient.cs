namespace FoodDeliveryService.Messaging
{
    public interface IMessageBrokerClient<T>
    {
        Task SendMessageAsync(MessageEnvelope message);
    }
}
