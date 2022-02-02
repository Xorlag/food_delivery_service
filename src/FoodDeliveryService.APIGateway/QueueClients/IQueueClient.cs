namespace FoodDeliveryService.APIGateway.QueueClients
{
    public interface IQueueClient<TCommand>
    {
        void Send(TCommand command);
    }
}
