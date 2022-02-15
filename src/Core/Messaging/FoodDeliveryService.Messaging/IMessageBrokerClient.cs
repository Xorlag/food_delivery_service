namespace FoodDeliveryService.Messaging
{
    public interface IMessageBrokerClient
    {
        Task SendMessageAsync(MessageEnvelope message);
    }
}
