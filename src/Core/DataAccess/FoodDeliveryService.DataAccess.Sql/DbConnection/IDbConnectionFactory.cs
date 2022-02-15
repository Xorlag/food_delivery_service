using System.Data;

namespace FoodDeliveryService.DataAccess.Sql.DbConnection
{
    public interface IDbConnectionFactory<TTargetRepo>
    {
        IDbConnection CreateConnection();
    }
}