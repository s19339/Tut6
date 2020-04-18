using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Tutorial6.Services
{
    public class SqlServerDbService : IDbService

    {


        public bool CheckIndex(string index)
        {


            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19339;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT * FROM student WHERE IndexNumber=@IndexNumber";
                com.Parameters.AddWithValue("IndexNumber", index);
                con.Open();
                var dr = com.ExecuteReader();
                if (!dr.Read())
                {
                    return false;
                }
                return true;


            }
        }
    }
}
