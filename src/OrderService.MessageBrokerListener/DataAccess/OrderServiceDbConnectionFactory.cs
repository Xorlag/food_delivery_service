using FoodDeliveryService.DataAccess.DbConnection;
using Microsoft.Extensions.Options;
using OrderService.DataAccess;
using OrderService.MessageBrokerListener.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.MessageBrokerListener.DataAccess
{
    internal class OrderServiceDbConnectionFactory : IDbConnectionFactory
    {
        private readonly DbConnectionStringsConfiguration _configuration;

        public OrderServiceDbConnectionFactory(IOptions<DbConnectionStringsConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }
        public IDbConnection CreateConnection(string connectionKey)
        {
            switch (connectionKey)
            {
                case OrderServiceDataAccessDbFactoryKeys.OrderServiceRepository:
                    return new SqlConnection(_configuration.OrderService_DatabaseConnectionString);
                default:
                    throw new ArgumentException($"Unsupported {nameof(connectionKey)}");
            }
        }
    }
}
