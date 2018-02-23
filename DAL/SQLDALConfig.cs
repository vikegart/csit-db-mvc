using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class SQLDALConfig
    {
        public static string cs = "Data Source=EPRUSARW0980\\SQLEXPRESS;Initial Catalog=AwardsDB;Integrated Security=True";
        public static string csn = ConfigurationManager.ConnectionStrings["DataAccess"].ConnectionString; //Err
        public static string ConnectionString { get; } = cs;
    }
}
