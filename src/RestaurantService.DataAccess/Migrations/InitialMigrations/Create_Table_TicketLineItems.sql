USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DeliveryInfo' and xtype='U')
    CREATE TABLE TicketLineItems (
        MenuItemId uniqueidentifier not null,
        Quantity int not null
    )
GO