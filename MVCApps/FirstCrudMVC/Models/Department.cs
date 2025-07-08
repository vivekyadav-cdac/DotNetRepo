using Humanizer;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FirstCrudMVC.Models
{
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }

        public static List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Departments";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Department dept = new Department
                    {
                        DeptNo = reader.GetInt32("DeptNo"),
                        DeptName = reader.GetString("DeptName")
                    };

                    departments.Add(dept);
                }
                return departments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
            return departments;
        }
    }
}
