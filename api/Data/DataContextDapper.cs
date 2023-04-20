using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductManagerAPI.Data
{
    public class DataContextDapper
    {
        private readonly IConfiguration _config;
        private readonly IDbConnection _connection;
        private readonly SqlConnection _dbConnection;

        public DataContextDapper(IConfiguration config)
        {
            _config = config;
            _connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            _dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            return _connection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql)
        {
            return _connection.QuerySingleOrDefault<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            return _connection.Execute(sql) > 0;
        }

        public int ExecuteSqlWithRowCount(string sql)
        {
            return _connection.Execute(sql);
        }

        public bool ExecuteSqlWithParameters(string sql, List<SqlParameter> parameters)
        {
            SqlCommand commandWithParams = new SqlCommand(sql);

            foreach (SqlParameter parameter in parameters)
            {
                commandWithParams.Parameters.Add(parameter);
            }
            _dbConnection.Open();
            commandWithParams.Connection = _dbConnection;

            int rowsAffected = commandWithParams.ExecuteNonQuery();
            _dbConnection.Close();

            return rowsAffected > 0;
        }
    }
}
