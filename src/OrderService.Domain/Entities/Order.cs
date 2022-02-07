using OrderService.Domain.DomainEvents;
using OrderService.Domain.Exceptions;

namespace OrderService.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public IEnumerable<OrderLineItem> OrderLineItems { get; set; }
        public OrderState State { get; set; }
        public IEnumerable<OrderDomainEvent> NoteApproved()
        {
            switch (State)
            {
                case OrderState.ApprovalPending:
                    State = OrderState.Approved;
                    break;
                default:
                    throw new UnsupportedStateTransitionException(State, OrderState.Approved);
            }
            return new OrderDomainEvent[]{
                new OrderApprovedEvent()
            };
        }
    }
}