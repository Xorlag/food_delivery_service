USE RestaurantServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DeliveryInfo' and xtype='U')
    CREATE TABLE Create_Table_MenuLineItems (
        MenuItemId uniqueidentifier not null,
        MenuId uniqueidentifier not null,
        Title varchar(max) not null
    )
GO