using FoodDeliveryService.Mappers;
using RestaurantService.Domain.Entities;
using RestaurantService.DTO.Messages;
using System.Linq;

namespace RestaurantService.MessageBrokerListener.MessageHandling.Mappers
{
    public class CreateTicketCommandToDetailsMapper : IMapper<CreateTicketCommand, TicketDetails>
    {
        public TicketDetails Map(CreateTicketCommand source)
        {
            var detailsDto = source.TicketDetails;
            return new TicketDetails
            {
                OrderId = detailsDto.OrderId,
                RestaurantId = detailsDto.RestaurantId,
                TicketLineItems = detailsDto.TicketLineItems.Select(tliDto => new TicketLineItem
                {
                    OrderId = tliDto.OrderId,
                    MenuLineItemId = tliDto.MenuLineItemId,
                    Quantity = tliDto.Quantity
                })
            };
        }
    }
}
