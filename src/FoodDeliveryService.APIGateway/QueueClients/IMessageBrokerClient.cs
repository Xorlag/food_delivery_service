namespace FoodDeliveryService.APIGateway.QueueClients
{
    public interface IMessageBrokerClient
    {
        Task SendMessage(object command);
    }
}
