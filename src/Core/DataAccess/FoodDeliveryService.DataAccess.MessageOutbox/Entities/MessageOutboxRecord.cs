namespace FoodDeliveryService.DataAccess.MessageOutbox.Entities
{
    public class MessageOutboxRecord
    {
        public Guid MessageId { get; set; }
        public byte[] MessagePayload { get; set; }
        public MessageOutboxStatus Status { get; set; }
    }
}
