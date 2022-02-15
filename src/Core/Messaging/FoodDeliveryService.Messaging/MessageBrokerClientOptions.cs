namespace FoodDeliveryService.Messaging
{
    public class MessageBrokerClientOptions
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
