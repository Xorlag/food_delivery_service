using OrderService.Domain.DomainEvents;
using OrderService.Domain.Entities;
using OrderService.Domain.Exceptions;

namespace OrderService.Domain.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public IEnumerable<OrderLineItem> OrderLineItems { get; set; }
        public OrderStatus State { get; set; }
        public IEnumerable<OrderDomainEvent> NoteApproved()
        {
            switch (State)
            {
                case OrderStatus.ApprovalPending:
                    State = OrderStatus.Approved;
                    break;
                default:
                    throw new UnsupportedStateTransitionException(State, OrderStatus.Approved);
            }
            return new OrderDomainEvent[]{
                new OrderApprovedEvent()
            };
        }
    }
}