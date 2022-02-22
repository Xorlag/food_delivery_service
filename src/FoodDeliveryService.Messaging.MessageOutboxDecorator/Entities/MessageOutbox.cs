namespace FoodDeliveryService.Messaging.MessageOutboxClient.Entities
{
    public class MessageOutbox
    {
        public Guid MessageId { get; set; }
        public byte[] MessagePayload { get; set; }
        public MessageOutboxStatus Status { get; set; }
    }
}
