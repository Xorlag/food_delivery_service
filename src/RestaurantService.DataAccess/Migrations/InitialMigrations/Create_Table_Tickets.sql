USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DeliveryInfo' and xtype='U')
    CREATE TABLE Tickets (
        OrderId uniqueidentifier not null,
        RestaurantId uniqueidentifier not null,
        TicketStatus smallint not null
    )
GO