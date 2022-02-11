using System.Data;

namespace FoodDeliveryService.DataAccess.DbConnection
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection(string connectionKey);
    }
}
