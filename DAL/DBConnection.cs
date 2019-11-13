using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnection
    {

        private static SqlConnection con;
        private static string constr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MyDataBase.mdf;Integrated Security=True";
        public static SqlConnection CreateDBConnection()
        {
            try
            {
                con = new SqlConnection(constr);
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return con;
        }
    }
}
