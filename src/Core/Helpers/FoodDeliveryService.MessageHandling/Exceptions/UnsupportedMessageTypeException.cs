using System;

namespace FoodDeliveryService.MessageHandling.Exceptions
{
    public class UnsupportedMessageTypeException : Exception
    {
        public UnsupportedMessageTypeException(string message) : base(message)
        {
        }
    }
}
