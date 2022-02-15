 IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'OrderServiceDb')
  BEGIN
    CREATE DATABASE [OrderServiceDb]
  END