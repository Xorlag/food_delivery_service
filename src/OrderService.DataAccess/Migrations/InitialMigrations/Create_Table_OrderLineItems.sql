USE OrderServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OrderLineItems' and xtype='U')
    CREATE TABLE OrderLineItems (
        OrderId uniqueidentifier not null,
		MenuLineItemId uniqueidentifier not null,
		Quantity int not null
    )
GO