using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataBase
{
    internal class AsyncDataConnectionWithNonWaitingCode
    {
        public static async Task AsyncSelectReader(string queryString)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ACTSJUNE25";

            try
            {
                await sqlConnection.OpenAsync();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = queryString;
                cmd.BeginExecuteReader( async(IAsyncResult ar)=>{
                    SqlDataReader dr = cmd.EndExecuteReader(ar);
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["Name"]);
                    }
                    await dr.CloseAsync();
                    sqlConnection.Close();
                },null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Some other work being done while connection is establishing...");
            
        }
        
    }
}
