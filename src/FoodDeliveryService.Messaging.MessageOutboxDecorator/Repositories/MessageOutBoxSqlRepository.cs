using Dapper;
using FoodDeliveryService.DataAccess.DataOperation;
using FoodDeliveryService.DataAccess.Sql.DbConnection;
using FoodDeliveryService.Messaging.MessageOutboxClient;
using FoodDeliveryService.Messaging.MessageOutboxClient.Entities;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace FoodDeliveryService.Messaging.MessageOutboxDecorator.Repositories
{
    internal class MessageOutBoxSqlRepository : IMessageOutboxRepository
    {
        private readonly IDbConnectionFactory<MessageOutBoxSqlRepository> _dbConnectionFactory;

        public MessageOutBoxSqlRepository(IDbConnectionFactory<MessageOutBoxSqlRepository> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<MessageEnvelope>> GetUnsentMessages()
        {
            using var sqlConnection = _dbConnectionFactory.CreateConnection();
            var getUnsentMessagesSql = @"SELECT MessageId, MessagePayload, DestinationKey, Status 
                                         FROM OutboxMessages
                                         WHERE Status = @status";

            var unsentOutboxMessages = await sqlConnection.QueryAsync<MessageOutbox>(getUnsentMessagesSql, new
            {
                Status = MessageOutboxStatus.ReadyToSend
            });
            return unsentOutboxMessages.Select(MapToMessageEnvelope);
        }

        public async Task<DataOperationResult> NotifyMessageSent(Guid messageId)
        {
            try
            {
                using var sqlConnection = _dbConnectionFactory.CreateConnection();
                var updateMessageSql = @"UPDATE OutboxMessages
                                         SET Status = @status
                                         WHERE MessageId = @messageId";

                int affectedRowsCount = await sqlConnection.ExecuteAsync(updateMessageSql, new
                {
                    status = MessageOutboxStatus.Sent,
                    messageId = messageId
                });
                if (affectedRowsCount > 0)
                {
                    return DataOperationResult.Success();
                }
                else
                {
                    return new DataOperationResult(DataOperationResultStatus.Failure, "No records were updated");
                }
            }
            catch (SqlException ex)
            {
                return new DataOperationResult(DataOperationResultStatus.Failure, ex.Message);
            }
        }

        public async Task<DataOperationResult> SaveOutboxMessage(MessageEnvelope messageEnvelope)
        {
            try
            {
                using var sqlConnection = _dbConnectionFactory.CreateConnection();
                var saveMessageSql = @"INSERT INTO OutboxMessages(MessageId, MessagePayload, Status)
                                   VALUES(@messageId, @messagePayload, @status)";

                var serializedEnvelope = JsonSerializer.Serialize(messageEnvelope);
                var messagePayloadBytes = Encoding.UTF8.GetBytes(serializedEnvelope);

                var affectedRowsCount = await sqlConnection.ExecuteAsync(saveMessageSql, new
                {
                    messageId = messageEnvelope.MessageId,
                    messagePayload = messagePayloadBytes,
                    status = MessageOutboxStatus.ReadyToSend
                });
                if (affectedRowsCount > 0)
                {
                    return DataOperationResult.Success();
                }
                else
                {
                    return new DataOperationResult(DataOperationResultStatus.Failure, "No records were saved");
                }
            }
            catch (SqlException ex)
            {
                return new DataOperationResult(DataOperationResultStatus.Failure, ex.Message);
            }
        }

        private MessageEnvelope MapToMessageEnvelope(MessageOutbox messageOutbox)
        {
            var serializedEnvelopeBytes = Encoding.UTF8.GetString(messageOutbox.MessagePayload);
            var messageEnvelope = JsonSerializer.Deserialize<MessageEnvelope>(serializedEnvelopeBytes);
            return messageEnvelope ?? throw new NullReferenceException("MessageEnvelope can not be null");
        }
    }
}
