namespace FoodDeliveryService.APIGateway.Services.OrderService
{
    public interface IOrderServiceConfiguration
    {
        public string OrderServiceMessageBrokerUrl { get; }
        public string OrderServiceQueueName { get; }
    }
}
