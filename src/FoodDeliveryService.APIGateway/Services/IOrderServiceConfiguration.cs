namespace FoodDeliveryService.APIGateway.Services
{
    public interface IOrderServiceConfiguration
    {
        public string OrderServiceMessageBrokerUrl { get; }
        public string OrderServiceQueueName { get; }
    }
}
