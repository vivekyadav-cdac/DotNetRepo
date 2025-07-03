using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class Insert
    {
        public static void Insert1()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;Integrated Security=True";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Employees values(15,'Alka',150000,20)";
                cmd.ExecuteNonQuery();

                Console.WriteLine("success");
            }
            catch(Exception  ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
