USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Menus' and xtype='U')
    CREATE TABLE Menus (
        MenuId uniqueidentifier not null,
        Title varchar(max) not null,
    )
GO