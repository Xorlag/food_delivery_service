using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Services
{
    internal class OrderService
    {
        private readonly IOrderServiceRepository _repository;

        internal OrderService(IOrderServiceRepository repository)
        {
            _repository = repository;
        }
        internal async Task<ServiceOperationResult> CreateOrder(OrderDetails orderDetails)
        {
            var order = new Order()
            {
                OrderLineItems = orderDetails.OrderLineItems,
                RestaurantId = orderDetails.RestaurantId,
                Id = orderDetails.OrderId,
                State = OrderState.ApprovalPending
            };
            _repository.SaveOrder(order);
            return new ServiceOperationResult();
        }
    }
}
