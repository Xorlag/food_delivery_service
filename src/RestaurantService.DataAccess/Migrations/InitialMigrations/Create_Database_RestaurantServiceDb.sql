 IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'RestaurantServiceDb')
  BEGIN
    CREATE DATABASE [RestaurantServiceDb]
  END