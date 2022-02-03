using FoodDeliveryService.APIGateway.Exceptions;
using RabbitMQ.Client;

namespace FoodDeliveryService.APIGateway.QueueClients.Factory
{
    public class RabbitMQClientFactory : IMessageBrokerClientFactory
    {
        private IConnectionFactory _connectionFactory;

        public RabbitMQClientFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IMessageBrokerClient CreateClient(MessageBrokerClientOptions options)
        {
           return new RabbitMQClient(_connectionFactory, options);
        }
    }
}
