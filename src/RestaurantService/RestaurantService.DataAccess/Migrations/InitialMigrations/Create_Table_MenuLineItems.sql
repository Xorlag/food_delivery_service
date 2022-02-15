USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='MenuLineItems' and xtype='U')
    CREATE TABLE MenuLineItems (
        MenuItemId uniqueidentifier not null,
        MenuId uniqueidentifier not null,
        Title varchar(max) not null,
		Price decimal(2) not null
    )
GO