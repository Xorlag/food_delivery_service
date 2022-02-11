namespace FoodDeliveryService.Messaging
{
    public interface IMessageBrokerClient
    {
        Task SendMessage(MessageEnvelope message);
    }
}
