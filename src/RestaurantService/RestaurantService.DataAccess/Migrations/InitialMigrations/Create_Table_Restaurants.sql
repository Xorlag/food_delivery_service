USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Restaurants' and xtype='U')
    CREATE TABLE Restaurants (
        RestaurantId uniqueidentifier not null,
        Title varchar(max) not null
    )
GO