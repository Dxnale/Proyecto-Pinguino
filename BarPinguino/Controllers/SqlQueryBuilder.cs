using Microsoft.Data.SqlClient;

namespace EVA2TI_BarPinguino.Controllers
{
    public class SqlQueryBuilder
    {
        private readonly string _connectionString;
        private readonly SqlCommand _command;

        public SqlQueryBuilder()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=taller_eva3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            _command = new SqlCommand();
        }

        public SqlQueryBuilder SetQuery(string query)
        {
            _command.CommandText = query;
            return this;
        }

        public SqlQueryBuilder AddParameter(string name, object value)
        {
            _command.Parameters.AddWithValue(name, value);
            return this;
        }

        public async Task<SqlDataReader> ExecuteReaderAsync()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            _command.Connection = connection;
            await connection.OpenAsync();
            return await _command.ExecuteReaderAsync(System.Data.CommandBehavior.CloseConnection);
        }

        public async Task<int> ExecuteNonQueryAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                _command.Connection = connection;
                await connection.OpenAsync();
                return await _command.ExecuteNonQueryAsync();
            }
        }
    }
}
