using RabbitMQ.Client;

namespace FoodDeliveryService.Messaging.RabbitMQ
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
