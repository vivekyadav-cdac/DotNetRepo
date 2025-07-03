using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class GetAllEmps
    {
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee emp = new Employee(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]), Convert.ToDecimal(dr[2]), Convert.ToInt32(dr[3]));
                    employees.Add(emp);
                }
                dr.Close();
                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();

            }
            return employees;
        }
    }
}
