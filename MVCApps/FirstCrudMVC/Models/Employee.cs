using Microsoft.Data.SqlClient;
using System.Data;

namespace FirstCrudMVC.Models
{
    public class Employee
    {
        public int EmpNo {  get; set; }
        public string Name {  get; set; }
        public decimal Basic {  get; set; }
        public int DeptNo {  get; set; }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee emp = new Employee {
                        EmpNo = reader.GetInt32("EmpNo"),
                        Name = reader.GetString("Name"),
                        Basic = reader.GetDecimal("Basic"),
                        DeptNo = reader.GetInt32("DeptNo")
                    };
                    
                    employees.Add(emp);
                }
                return employees;   
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
            return employees;
        }

        public static Employee GetEmployee(int empNo)
        {
            Employee employee = null!;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo = @empNo";
                cmd.Parameters.AddWithValue("@EmpNo", empNo);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee
                    {
                        EmpNo = reader.GetInt32("EmpNo"),
                        Name = reader.GetString("Name"),
                        Basic = reader.GetDecimal("Basic"),
                        DeptNo = reader.GetInt32("DeptNo")
                    };

                    return employee;
                }
  
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
            return employee;

        }

         public static void Create(Employee emp)
         {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;Integrated Security=True";
            try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Employees(EmpNo,Name,Basic,DeptNo) values(@EmpNo,@Name,@Basic,@DeptNo)";
                    cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                    cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                Console.WriteLine(ex.Message);
                throw;
                }
            finally { con.Close(); }
         }

        public static void Update(int EmpNo,Employee emp)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE Employees 
                            SET Name = @Name, 
                                Basic = @Basic, 
                                DeptNo = @DeptNo 
                            WHERE EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update error: " + ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public static void Delete(int empNo)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Employees WHERE EmpNo = @EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", empNo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Error: " + ex.Message);
                throw;
            }
            finally
            {
                con.Close();
            }
        }


    }

}
//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;