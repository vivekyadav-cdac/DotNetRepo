using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataBase
{
    public class DataSetApp
    {
        public static void PersistData()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ACTSJUNE25";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();

            }
            catch(Exception ex)
            {

            }
        }
    }
}
//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ACTSJUNE25;