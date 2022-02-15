USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TicketLineItems' and xtype='U')
    CREATE TABLE TicketLineItems (
        TicketId uniqueidentifier not null,
        MenuItemId uniqueidentifier not null,
        Quantity int not null
    )
GO