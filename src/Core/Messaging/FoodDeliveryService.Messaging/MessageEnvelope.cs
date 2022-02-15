using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryService.Messaging
{
    public class MessageEnvelope
    {
        public MessageEnvelope(Guid messageId, string message, string type)
        {
            MessageId = messageId;
            Message = message;
            Type = type;
        }

        public Guid MessageId { get; }
        public string Message { get; }
        public string Type { get; }
    }
}
