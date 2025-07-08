using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataBase
{
    internal class AsyncConnection
    {
        public static async void AsyncConnCode()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "";

            Task t = conn.OpenAsync();
            // do other code here i.e. other unrelated code
            if(!t.IsCompleted)
                t.Wait();// we are waiting here so that the unrealated task completes

            //code after conn is opened i.e. code that requires connection 
            await conn.CloseAsync();
        }

        public static async Task AsyncCommand(Employee emp)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ACTSJUNE25"; ;

            await conn.OpenAsync();
            try
            {
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "INSERT INTO Employees (EmpNo, Name, Basic, DeptNo) VALUES (@EmpNo, @Name, @Basic, @DeptNo)";
                cmdInsert.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", emp.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", emp.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                await cmdInsert.ExecuteNonQueryAsync();
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
               await conn.CloseAsync();
            }
        }
    }
}
