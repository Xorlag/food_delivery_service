using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace FoodDeliveryService.APIGateway.QueueClients
{
    public class RabbitMQClient : IMessageBrokerClient
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly MessageBrokerClientOptions _options;

        public RabbitMQClient(IConnectionFactory connectionFactory, MessageBrokerClientOptions options)
        {
            _connectionFactory = connectionFactory;
            _options = options;
        }

        public Task SendMessage(object message)
        {
            return Task.Factory.StartNew(() =>
            {
                using var connection = _connectionFactory.CreateConnection(new[] { _options.HostUrl });
                using var channel = connection.CreateModel();
                channel.QueueDeclare(_options.QueueName, durable: true, exclusive: false, autoDelete: false);
                var serializedMessage = JsonSerializer.Serialize(message);
                var ampqBody = Encoding.UTF8.GetBytes(serializedMessage);
                channel.BasicPublish(exchange: "", routingKey: _options.QueueName, body: ampqBody);
            });
        }
    }
}
