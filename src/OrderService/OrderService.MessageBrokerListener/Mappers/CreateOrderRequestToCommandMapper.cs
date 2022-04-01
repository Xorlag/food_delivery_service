using FoodDeliveryService.Mappers;
using OrderService.Domain.Entities;
using OrderService.Domain.Models.Entities;
using OrderService.DTO.Messages;
using System.Linq;

namespace OrderService.FunctionsApp.Mappers
{
    public class CreateOrderRequestToCommandMapper : IMapper<CreateOrderCommand, OrderDetails>
    {
        public OrderDetails Map(CreateOrderCommand source)
        {
            var dtoOrderDetails = source.OrderDetails;
            return new OrderDetails
            {
                OrderId = dtoOrderDetails.OrderId,
                CustomerId = dtoOrderDetails.CustomerId,
                OrderLineItems = dtoOrderDetails.OrderLineItems.Select(dtoItem => new OrderLineItem
                {
                    MenuLineItemId = dtoItem.MenuLineItemId,
                    OrderId = dtoItem.OrderId,
                    Quantity = dtoItem.Quantity
                }),
                RestaurantId = dtoOrderDetails.RestaurantId,
                DeliveryInfo = new DeliveryInfo
                {
                    OrderId = dtoOrderDetails.DeliveryInfo.OrderId,
                    ApartmentsNumber = dtoOrderDetails.DeliveryInfo.ApartmentsNumber,
                    BuildingNumber = dtoOrderDetails.DeliveryInfo.BuildingNumber,
                    City = dtoOrderDetails.DeliveryInfo.City,
                    Street = dtoOrderDetails.DeliveryInfo.Street
                },
            };
        }
    }
}
