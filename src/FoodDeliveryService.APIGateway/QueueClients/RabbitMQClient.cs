
using MassTransit;
using System.Text.Json;

namespace FoodDeliveryService.APIGateway.QueueClients
{
    public class RabbitMQClient : IMessageBrokerClient
    {
        private IBus _bus;

        public RabbitMQClient(IBus bus)
        {
            _bus = bus;
        }

        public async Task SendMessage(object command)
        {
            //_bus.Send()
            var x = await _bus.GetSendEndpoint(new Uri(""));
            await _bus.Send(command);
        }
    }
}
