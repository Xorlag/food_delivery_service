using OrderService.DTO.Entities;

namespace OrderService.DTO.Messages
{
    public class CreateOrderCommand
    {
        public OrderDetailsDTO OrderDetails { get; set; }
    }
}
