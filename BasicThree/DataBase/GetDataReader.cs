using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class GetDataReader
    {
        public static async Task<SqlDataReader> GetSqlDataReader(string connectionString,string queryString)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlDataReader dataReader;
            
            try
            {
                await conn.OpenAsync();
                using(SqlCommand sqlCommand = new SqlCommand()){
                    sqlCommand.Connection = conn;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = queryString;

                    dataReader = await sqlCommand.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                    return dataReader;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                
            }
        }
    }
}
