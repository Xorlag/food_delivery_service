using OrderService.Domain.Entities;

namespace OrderService.Domain.Exceptions
{
    public class UnsupportedStateTransitionException : Exception
    {
        private readonly OrderStatus _originalState;
        private readonly OrderStatus _targetState;

        public UnsupportedStateTransitionException(OrderStatus originalState, OrderStatus targateState)
        {
            _originalState = originalState;
            _targetState = targateState;
        }
    }
}
