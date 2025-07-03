using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class Insert2
    {
        static void InsertUsingObject(Employee emp)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;Integrated Security=True";

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into Employees values({emp.DeptNo},{emp.Name},{emp.Basic},{emp.DeptNo})";

                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
