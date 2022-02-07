namespace FoodDeliveryService.APIGateway.Core.Messaging
{
    public interface IMessageBrokerClient
    {
        Task SendMessage(object command);
    }
}
