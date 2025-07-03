using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class GetSingleEmp
    {
        public static Employee GetSingleEmployee(int EmpNo)
        {
            Employee emp = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo = @EmpNo";

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                     emp = new Employee(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]), Convert.ToDecimal(dr[2]), Convert.ToInt32(dr[3]));
                   
                }
                dr.Close();
                return emp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();

            }
            return emp;
        }
    }
}
