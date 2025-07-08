using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataBase
{
    internal class DataTableDataSet
    {
        public static void CrudUsingDataSet()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ACTSJUNE25";

            try
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(ad);//SqlCommandBuilder with the SqlDataAdapter. This auto-generates the INSERT, UPDATE, and DELETE commands based on your original SELECT.

                DataSet ds = new DataSet();
                ad.Fill(ds, "Employees");

                DataTable dt = ds.Tables["Employees"]!;
                dt.PrimaryKey = new DataColumn[] { dt.Columns["EmpNo"]! };// The DataTable.Rows.Find(key) method requires the table to have a primary key defined in the in-memory DataTable — otherwise it throws: System.MissingPrimaryKeyException: Table doesn't have a primary key.
                                                                          //This has nothing to do with the database itself — even if your SQL table has a primary key — the DataTable loaded via SqlDataAdapter does not automatically assign it.
                                                                          //SqlDataAdapter.Fill() fetches the data, but doesn't assign metadata like primary keys unless explicitly told.
                                                                          //Setting PrimaryKey allows Find(), Select(), Delete() to work with index efficiency.
                Console.WriteLine("Before Any Changes:");
                DisplayTable(dt!);


                // MODIFY
                DataRow? existingRow = dt.Rows.Find(2); // EmpNo must be primary key
                if (existingRow != null)
                    existingRow["Basic"] = (decimal)existingRow["Basic"] + 5000;

                // INSERT
                DataRow newRow = dt.NewRow();
                newRow["EmpNo"] = 33;
                newRow["Name"] = "Harika";
                newRow["Basic"] = 60000;
                newRow["DeptNo"] = 10;
                dt.Rows.Add(newRow);

                // DELETE
                foreach (DataRow row in dt.Select("EmpNo = 2"))
                    row.Delete();

                Console.WriteLine("\nChanges BEFORE Update:");
                DisplayChanges(dt);

                // Save to DB
                ad.Update(dt);

                Console.WriteLine("\nAfter Update:");
                DisplayTable(dt); // Now all rows should be Unchanged

                ds.AcceptChanges(); // Optional after update

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DisplayTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"{row["EmpNo"],-5} {row["Name"],-15} {row["Basic"],10} {row["DeptNo"],5} [State: {row.RowState}]");
            }

        }

        static void DisplayChanges(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Unchanged) continue;

                Console.WriteLine($"\nRow State: {row.RowState}");

                if (row.RowState == DataRowState.Added)
                {
                    Console.WriteLine(" - New Row:");
                    Console.WriteLine($"   EmpNo: {row["EmpNo"]}, Name: {row["Name"]}, Basic: {row["Basic"]}, DeptNo: {row["DeptNo"]}");
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    Console.WriteLine(" - Original vs Current:");
                    Console.WriteLine($"   Original Basic: {row["Basic", DataRowVersion.Original]}");
                    Console.WriteLine($"   Current  Basic: {row["Basic", DataRowVersion.Current]}");
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    Console.WriteLine(" - Deleted Row:");
                    Console.WriteLine($"   EmpNo: {row["EmpNo", DataRowVersion.Original]}, Name: {row["Name", DataRowVersion.Original]}");
                }
            }
        }   
    }
}
