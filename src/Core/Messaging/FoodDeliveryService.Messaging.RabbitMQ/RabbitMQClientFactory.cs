using RabbitMQ.Client;

namespace FoodDeliveryService.Messaging.RabbitMQ
{
    public class RabbitMQClientFactory<T> : IMessageBrokerClientFactory<T>
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly RabbitMQClientOptions _options;

        public RabbitMQClientFactory(IConnectionFactory connectionFactory, RabbitMQClientOptions options)
        {
            _connectionFactory = connectionFactory;
            _options = options;
        }

        public IMessageBrokerClient<T> CreateClient()
        {
            return new RabbitMQClient<T>(_connectionFactory, _options);
        }
    }
}
