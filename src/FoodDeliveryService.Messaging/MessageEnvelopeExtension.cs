using System.Text.Json;

namespace FoodDeliveryService.Messaging
{
    public static class MessageEnvelopeExtension
    {
        public static T? Unwrap<T>(this MessageEnvelope messageEnvelope)
        {
            var messageObject = JsonSerializer.Deserialize<T>(messageEnvelope.Message);
            return messageObject;
        }
    }
}
