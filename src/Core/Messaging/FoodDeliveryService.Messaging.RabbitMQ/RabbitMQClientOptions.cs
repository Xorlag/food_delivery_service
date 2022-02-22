namespace FoodDeliveryService.Messaging.RabbitMQ
{
    public class RabbitMQClientOptions
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
