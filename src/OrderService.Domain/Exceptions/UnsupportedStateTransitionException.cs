using OrderService.Domain.Entities;

namespace OrderService.Domain.Exceptions
{
    public class UnsupportedStateTransitionException : Exception
    {
        private readonly OrderState _originalState;
        private readonly OrderState _targetState;

        public UnsupportedStateTransitionException(OrderState originalState, OrderState targateState)
        {
            _originalState = originalState;
            _targetState = targateState;
        }
    }
}
