USE OrderServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' and xtype='U')
    CREATE TABLE Orders (
        OrderId uniqueidentifier not null,
        CustomerId uniqueidentifier not null,
        RestaurantId uniqueidentifier not null,
		OrderStatus tinyint not null
    )
GO