using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class UpdateDataBase
    {
        public static void Update(Employee emp)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;Integrated Security=True";

            try
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Connection = sqlConnection;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Employee set Name = @Name,Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo";
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
