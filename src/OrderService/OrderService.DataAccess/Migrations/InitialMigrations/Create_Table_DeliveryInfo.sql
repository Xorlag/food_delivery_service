USE OrderServiceDb
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DeliveryInfo' and xtype='U')
    CREATE TABLE DeliveryInfo (
        OrderId uniqueidentifier not null,
		City nvarchar(max) not null,
		Street nvarchar(max) not null,
		BuildingNumber int not null,
		ApartmentsNumber int null
    )
GO