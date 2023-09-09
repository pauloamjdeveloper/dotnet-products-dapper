using System.Data;

namespace Products.Dapper.WebAPI.Data
{
    public interface IConnectionDataBase
    {
        IDbConnection GetDbConnection();
    }
}
