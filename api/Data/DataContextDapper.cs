using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace api.Data
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

        public IEnumerable<T> LoadData<T>(string sql, object? parameters = null)
        {
            return _connection.Query<T>(sql, parameters);
        }

        public T LoadDataSingle<T>(string sql, object? parameters = null)
        {
            return _connection.QuerySingleOrDefault<T>(sql, parameters);
        }

        public bool ExecuteSql(string sql)
        {
            return _connection.Execute(sql) > 0;
        }

        public int ExecuteSqlWithRowCount(string sql)
        {
            return _connection.Execute(sql);
        }

        //public bool ExecuteSqlWithParameters(string sql, List<SqlParameter> parameters)
        public bool ExecuteSqlWithParameters(string sql, object parameters)
        {
            //SqlCommand commandWithParams = new SqlCommand(sql);

            //foreach (SqlParameter parameter in parameters)
            //{
            //    commandWithParams.Parameters.Add(parameter);
            //}
            //_dbConnection.Open();
            //commandWithParams.Connection = _dbConnection;

            //int rowsAffected = commandWithParams.ExecuteNonQuery();
            //_dbConnection.Close();

            //return rowsAffected > 0;
            _dbConnection.Open();
            int rowsAffected = _dbConnection.Execute(sql, parameters);
            _dbConnection.Close();

            return rowsAffected > 0;
        }
        
    }
}
