USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Tickets' and xtype='U')
    CREATE TABLE Tickets (
        TicketId uniqueidentifier not null,
        RestaurantId uniqueidentifier not null,
        TicketStatus smallint not null
    )
GO