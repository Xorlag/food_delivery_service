using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace FoodDeliveryService.Messaging.RabbitMQ
{
    public class RabbitMQClient<T> : IMessageBrokerClient<T>
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly RabbitMQClientOptions _options;

        public RabbitMQClient(IConnectionFactory connectionFactory, RabbitMQClientOptions options)
        {
            _connectionFactory = connectionFactory;
            _options = options;
        }

        public Task SendMessageAsync(MessageEnvelope message)
        {
            return Task.Factory.StartNew(() =>
            {
                using var connection = _connectionFactory.CreateConnection(new[] { _options.ConnectionString });
                using var channel = connection.CreateModel();
                channel.QueueDeclare(_options.QueueName, durable: true, exclusive: false, autoDelete: false);
                var serializedMessage = JsonSerializer.Serialize(message);
                var ampqBody = Encoding.UTF8.GetBytes(serializedMessage);
                channel.BasicPublish(exchange: "", routingKey: _options.QueueName, body: ampqBody);
            });
        }
    }
}
