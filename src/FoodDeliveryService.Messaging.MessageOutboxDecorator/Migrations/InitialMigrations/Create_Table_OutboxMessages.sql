IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OutboxMessages' and xtype='U')
    CREATE TABLE OutboxMessages(
					MessageId uniqueidentifier,
					MessagePayload varbinary(max),
					Status smallint
					)
GO