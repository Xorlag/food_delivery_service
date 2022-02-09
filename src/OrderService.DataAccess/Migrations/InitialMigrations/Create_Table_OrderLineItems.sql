USE OrderServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OrderLineItems' and xtype='U')
    CREATE TABLE OrderLineItems (
        OrderId varchar(36) not null,
		OrderLineItemId varchar(36) not null,
		MenuLineItemId varchar(36) not null,
		Quantity int not null
    )
GO