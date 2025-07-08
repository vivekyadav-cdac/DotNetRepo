using Microsoft.Data.SqlClient;
using System.Data;
using StudentMVC.ExceptionHandler;
using StudentMVC.Utils;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;

namespace StudentMVC.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Enter roll number")]
        public int RollNo { get; set; }
        public string Name { get; set; }

        public string Subject { get; set; }

        public decimal Marks { get; set; }

        public Student() { }
        public Student(int rollNo, string name, string subject, decimal marks)
        {
            RollNo = rollNo;
            Name = name;
            Subject = subject;
            Marks = marks;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"RollNo: {RollNo}, Name: {Name}, Subject: {Subject}, Marks: {Marks}";
        }

        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            SqlConnection connection = DBConnection.OpenConnection();
            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Students";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    students.Add(new Student(reader.GetInt32("RollNo"),
                                             reader.GetString("Name"),
                                             reader.GetString("Subject"),
                                             reader.GetDecimal("Marks")));
                }
                return students;
            }
            catch (Exception ex)
            {
                throw new StudentException(ex.Message);
            }
            finally { 
                if(connection!= null)
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        public static Student GetStudent(int RollNo)
        {
            Student? student = null;
            SqlConnection connection = DBConnection.OpenConnection();
            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Students where RollNo = @RollNo";
                cmd.Parameters.AddWithValue("@RollNo", RollNo);

                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {

                    student = new Student(reader.GetInt32("RollNo"),
                                             reader.GetString("Name"),
                                             reader.GetString("Subject"),
                                             reader.GetDecimal("Marks"));
                }
                return student!;
            }
            catch (Exception ex)
            {
                throw new StudentException(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        public static void Create(Student obj)
        {
            SqlConnection connection = DBConnection.OpenConnection();
            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Students(RollNo,Name,Subject,Marks) values(@RollNo,@Name,@Subject,@Marks)";
                cmd.Parameters.AddWithValue("@RollNo", obj.RollNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Subject", obj.Subject);
                cmd.Parameters.AddWithValue("@Marks", obj.Marks);

                 cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new StudentException(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    DBConnection.CloseConnection();
                }
            }
        }
        public static void Update(int RollNo , Student obj)
        {
            SqlConnection connection = DBConnection.OpenConnection();
            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Students set Name = @Name,Subject = @Subject,Marks = @Marks where RollNo = @RollNo";
                cmd.Parameters.AddWithValue("@RollNo", obj.RollNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Subject", obj.Subject);
                cmd.Parameters.AddWithValue("@Marks", obj.Marks);

                int num = cmd.ExecuteNonQuery();
                if(num == 0)
                {
                    throw new StudentException("No such student in database");
                }

            }
            catch (Exception ex)
            {
                throw new StudentException(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    DBConnection.CloseConnection();
                }
            }
        }

        public static void Delete(int RollNo)
        {
            SqlConnection connection = DBConnection.OpenConnection();
            try
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Students where RollNo = @RollNo";
                cmd.Parameters.AddWithValue("@RollNo", RollNo);

                int num = cmd.ExecuteNonQuery();
                if (num == 0)
                {
                    throw new StudentException("No such student in database");
                }

            }
            catch (Exception ex)
            {
                throw new StudentException(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    DBConnection.CloseConnection();
                }
            }
        }
    }
}
