using OrderService.DTO;

namespace OrderService.Messages
{
    public class CreateOrderCommand
    {
       public OrderDetailsDTO OrderDetails { get; set; }
    }
}
