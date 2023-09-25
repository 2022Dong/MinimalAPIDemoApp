using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
// Dapper talks to DB
namespace DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    // using async: not lock up the UI whille we calling the DB
    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "Default")
    {
        // Dapper talks to DB
        // "using" : will automatically close the DB
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        // talk to SQL server
        return await connection.QueryAsync<T>(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }
}
