using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class AsyncUsingDelegates
    {
        public static async void UsingDelegates()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "";

            await conn.OpenAsync();
            try
            {
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "";
                await cmdInsert.ExecuteNonQueryAsync();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
