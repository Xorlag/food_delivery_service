using FoodDeliveryService.APIGateway.Exceptions;
using MassTransit;

namespace FoodDeliveryService.APIGateway.QueueClients.Factory
{
    public class RabbitMQClientFactory : IMessageBrokerClientFactory
    {
        private IBus _bus;

        public RabbitMQClientFactory(IBus bus)
        {
            _bus = bus;
        }

        public IMessageBrokerClient CreateClient(TargetServices targetService)
        {
            switch (targetService)
            {
                case TargetServices.OrderService:
                    return new RabbitMQClient(_bus);
                default:
                    throw new ServiceNotSupportedException();
            }
        }
    }
}
