USE OrderServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' and xtype='U')
    CREATE TABLE Orders (
        OrderId varchar(36) not null,
        CustomerId varchar(36) not null,
		OrderStatus tinyint not null
    )
GO