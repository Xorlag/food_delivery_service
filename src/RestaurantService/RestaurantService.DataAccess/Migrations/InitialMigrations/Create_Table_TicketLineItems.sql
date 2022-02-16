USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TicketLineItems' and xtype='U')
    CREATE TABLE TicketLineItems (
        OrderId uniqueidentifier not null,
        MenuLineItemId uniqueidentifier not null,
        Quantity int not null
    )
GO
