using OrderService.DTO.Entities;

namespace OrderService.Proxy
{
    public interface IOrderServiceProxy
    {
        public Task CreateOrder(OrderDetailsDTO orderDetails);

        public Task NotifyOrderAccepted(Guid orderId);
    }
}
