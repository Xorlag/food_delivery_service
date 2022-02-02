using FoodDeliveryService.APIGateway.Commands;

namespace FoodDeliveryService.APIGateway.QueueClients
{
    public class CreateOrderCommandQueueClient : IQueueClient<CreateOrderCommand>
    {
        public void Send(CreateOrderCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
