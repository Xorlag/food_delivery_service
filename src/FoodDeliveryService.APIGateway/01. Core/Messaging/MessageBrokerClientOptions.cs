namespace FoodDeliveryService.APIGateway.Core.Messaging
{
    public class MessageBrokerClientOptions
    {
        public string HostUrl { get; set; }
        public string QueueName { get; set; }
    }
}
