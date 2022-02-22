using System.Text.Json;

namespace FoodDeliveryService.Messaging
{
    public static class MessageEnvelopeExtension
    {
        public static TPayload? Unwrap<TPayload>(this MessageEnvelope messageEnvelope)
        {
            var messageObject = JsonSerializer.Deserialize<TPayload>(messageEnvelope.Message);
            return messageObject;
        }
    }
}
