using Microsoft.Data.SqlClient;

namespace StudentMVC.Utils
{
    public class DBConnection
    {
        private static SqlConnection? _connection;
        private static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;Trust Server Certificate=True;";

        public static SqlConnection OpenConnection()
        {
            if( _connection == null)
            {
                _connection = new SqlConnection(ConnectionString);
                _connection.Open();
            }
            return _connection;
        }

        public static void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}
