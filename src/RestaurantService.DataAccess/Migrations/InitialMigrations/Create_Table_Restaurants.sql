USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DeliveryInfo' and xtype='U')
    CREATE TABLE Tickets (
        RestaurantId uniqueidentifier not null,
        Title varchar(max) not null
    )
GO