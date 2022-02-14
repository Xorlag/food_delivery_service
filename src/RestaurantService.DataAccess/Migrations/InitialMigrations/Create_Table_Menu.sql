USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DeliveryInfo' and xtype='U')
    CREATE TABLE Tickets (
        MenuId uniqueidentifier not null,
        Title varchar(max) not null,
    )
GO