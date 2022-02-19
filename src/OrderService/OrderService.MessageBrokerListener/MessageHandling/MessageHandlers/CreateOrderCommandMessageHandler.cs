using System.Threading.Tasks;
using FoodDeliveryService.MessageHandling;
using FoodDeliveryService.Messaging;
using OrderService.DTO.Messages;
using OrderService.MessageBrokerListener.Mappers;

namespace OrderService.MessageBrokerListener.MessageHandling.MessageHandlers
{
    internal class CreateOrderCommandMessageHandler : IMessageHandler
    {
        private readonly Domain.Services.OrderService _orderService;

        public CreateOrderCommandMessageHandler(OrderService.Domain.Services.OrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task HandleMessage(MessageEnvelope messageEnvelope)
        {
            var createOrderCommand = messageEnvelope.Unwrap<CreateOrderCommand>();
            var createOrderCommandToDetailsMapper = new CreateOrderRequestToCommandMapper();
            var orderDetails = createOrderCommandToDetailsMapper.Map(createOrderCommand);
            await _orderService.CreateOrder(orderDetails);
        }
    }
}
