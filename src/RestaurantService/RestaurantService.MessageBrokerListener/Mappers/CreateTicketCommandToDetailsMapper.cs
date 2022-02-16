using FoodDeliveryService.Mappers;
using RestaurantService.Domain.Entities;
using RestaurantService.Messages;
using System.Linq;

namespace RestaurantService.MessageBrokerListener.Mappers
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
                    TicketId = tliDto.TicketId,
                    MenuLineItemId = tliDto.MenuLineItemId,
                    Quantity = tliDto.Quantity
                })
            };
        }
    }
}
