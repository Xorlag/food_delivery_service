namespace FoodDeliveryService.APIGateway.MessageBrokerClients
{
    public interface IMessageBrokerClient
    {
        Task SendMessage(object command);
    }
}
